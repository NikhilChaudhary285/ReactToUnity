using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics; // Include for Process
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

[CustomEditor(typeof(UIManager))]
public class UIManagerEditor : Editor
{
    private UIManager uiManager;
    private Dictionary<string, bool> elementFoldouts;

    private void OnEnable()
    {
        uiManager = (UIManager)target;
        elementFoldouts = new Dictionary<string, bool>();

        if (uiManager == null)
        {
            Debug.LogError("UIManager instance not found!");
            return;
        }
    }

    public override void OnInspectorGUI()
    {
        if (uiManager == null)
        {
            EditorGUILayout.HelpBox("UIManager not found.", MessageType.Error);
            return;
        }

        GUILayout.Label("UI Manager Editor", EditorStyles.boldLabel);
        DisplayUIHierarchySection();

        if (GUILayout.Button("Update UI Library"))
        {
            UpdateUILibrary();
        }

        if (GUILayout.Button("Open UI Library"))
        {
            OpenUILibrary();
        }

        DrawDefaultInspector();
    }

    private void DisplayUIHierarchySection()
    {
        GUILayout.BeginVertical("box");
        GUILayout.Label("UI Hierarchy", EditorStyles.boldLabel);

        var canvases = GameObject.FindObjectsOfType<Canvas>();
        if (canvases.Length == 0)
        {
            EditorGUILayout.HelpBox("No Canvases found in the scene.", MessageType.Info);
        }
        else
        {
            foreach (var canvas in canvases)
            {
                DrawUIHierarchy(canvas.transform, 0, canvas.gameObject.name);
            }
        }
        GUILayout.EndVertical();
    }

    private void DrawUIHierarchy(Transform transform, int indentLevel, string path)
    {
        string elementPath = path + "/" + transform.name;
        bool foldoutState = elementFoldouts.ContainsKey(elementPath) ? elementFoldouts[elementPath] : false;

        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(indentLevel * 20);

        if (transform.childCount > 0)
        {
            foldoutState = EditorGUILayout.Foldout(foldoutState, transform.name, true);
            elementFoldouts[elementPath] = foldoutState;
        }
        else
        {
            EditorGUILayout.LabelField(transform.name);
        }

        if (GUILayout.Button("Add", GUILayout.Width(100)))
        {
            Debug.Log($"Adding UI element: {transform.name}");
            uiManager.AddUIReference(transform.gameObject);
            EditorUtility.SetDirty(uiManager);
            AssetDatabase.Refresh();
        }
        EditorGUILayout.EndHorizontal();

        if (foldoutState)
        {
            foreach (Transform child in transform)
            {
                DrawUIHierarchy(child, indentLevel + 1, elementPath);
            }
        }
    }

    private void UpdateUILibrary()
    {
        try
        {
            Debug.Log("Starting UI Library update...");

            var uiElements = uiManager.GetAllUICategories()
                .SelectMany(category => category.references.Select(reference => new { Category = category.name, Element = reference }))
                .GroupBy(item => item.Category)
                .ToList();

            string filePath = GetLibraryFilePath();
            string fileContent = File.ReadAllText(filePath);

            foreach (var categoryGroup in uiElements)
            {
                StringBuilder sbPaths = new StringBuilder();
                StringBuilder sbIDs = new StringBuilder();

                foreach (var item in categoryGroup)
                {
                    string safeName = item.Element.name.Replace(" ", "_");
                    sbPaths.AppendLine(GenerateConstantDeclaration(safeName + "_Path", item.Element.fullPath));
                    sbIDs.AppendLine(GenerateConstantDeclaration(safeName + "_ID", item.Element.instanceID.ToString()));
                    Debug.Log($"Updating {categoryGroup.Key}: {safeName}");
                }

                fileContent = InsertContentIntoRegion(fileContent, $"#region {categoryGroup.Key.ToUpper()}_PATHS", sbPaths.ToString());
                fileContent = InsertContentIntoRegion(fileContent, $"#region {categoryGroup.Key.ToUpper()}_IDS", sbIDs.ToString());
            }

            File.WriteAllText(filePath, fileContent);
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(target); // Ensure changes are saved

            Debug.Log("UI Library updated successfully.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to update UI Library: {ex.Message}");
        }
    }

    private void OpenUILibrary()
    {
        string filePath = GetLibraryFilePath();
        Process.Start(filePath);
        Debug.Log($"Opening UI Library: {filePath}");
    }

    private string GenerateConstantDeclaration(string constantName, string value)
    {
        return $"    public const string {constantName} = \"{value}\";";
    }

    private string GetLibraryFilePath()
    {
        return Path.Combine(Application.dataPath, "Scripts/Library/UI_Library.cs");
    }

    private string InsertContentIntoRegion(string content, string regionTag, string insertion)
    {
        string pattern = $@"({regionTag}\s*?)(.*?)(#endregion)";
        string replacement = $"$1\n    // Automatically updated\n{insertion}\n    $3";
        return System.Text.RegularExpressions.Regex.Replace(content, pattern, replacement, System.Text.RegularExpressions.RegexOptions.Singleline);
    }
}
