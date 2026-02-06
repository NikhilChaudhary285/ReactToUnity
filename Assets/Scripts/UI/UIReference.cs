using UnityEngine;

[System.Serializable]
public class UIReference
{
	public string name;
	public string fullPath;
	public string instanceID;
	public GameObject uiElement;
	public UIElementType elementType;
}

public enum UIElementType
{
	Panel,
	Button,
	Text,
	TMP_Text,
	Toggle,
	InputField,
	TMP_InputField,
	Slider,
	Dropdown,
	TMP_Dropdown,
	ScrollView,
	Image,
	RawImage,
	Mask,
	Canvas,
	CanvasGroup,
	Unknown
}
