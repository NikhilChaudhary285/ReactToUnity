using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BridgeController : MonoBehaviour
{
	// Singleton instance
	public static BridgeController Instance { get; private set; }

	[Header("Settings")]
	[SerializeField] private float loadDelay = 0.1f; // Short buffer to ensure scene initialization

	private TMP_Text _centerText;

	protected virtual void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	/// <summary>
	/// Called from React Native: unityRef.current.postMessage("Scene1")
	/// </summary>
	public void LoadSpecificLevel(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			Debug.LogWarning("BridgeController: Received empty scene name from React Native.");
			return;
		}

		StartCoroutine(ProcessSceneChange(sceneName));
	}

	private IEnumerator ProcessSceneChange(string sceneName)
	{
		// 1. Load the scene asynchronously
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

		// 2. Wait until the scene is fully loaded
		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		// 3. Optional: Wait a tiny bit for Start() methods in the new scene to fire
		yield return new WaitForSeconds(loadDelay);

		// 4. Update UI
		UpdateSceneUI(sceneName);
	}

	private void UpdateSceneUI(string sceneName)
	{
		// Search for the specific TextMeshPro component
		// Using a Tag like "LevelTitle" is more reliable than FindFirstObjectByType
		_centerText = GameObject.FindGameObjectWithTag("LevelTitle")?.GetComponent<TMP_Text>();

		// Fallback: if no tag is found, try finding the first TMP_Text
		if (_centerText == null)
		{
			_centerText = FindFirstObjectByType<TMP_Text>();
		}

		if (_centerText != null)
		{
			_centerText.text = GetDisplayName(sceneName);
		}
		else
		{
			Debug.LogError($"BridgeController: No TMP_Text found in {sceneName}!");
		}
	}

	private string GetDisplayName(string sceneName)
	{
		// A cleaner way to map internal names to UI display names
		return sceneName switch
		{
			"Scene1" => "Level 1",
			"Scene2" => "Level 2",
			"Scene3" => "Level 3",
			_ => "Unknown Level"
		};
	}
}