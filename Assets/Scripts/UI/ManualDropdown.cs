using UnityEngine;
using UnityEngine.UI;
using TMPro; // remove if not using TMP

public class ManualDropdown : MonoBehaviour
{
	[Header("UI References")]
	public GameObject optionsPanel;
	public TMP_Text selectedLabel; // or Text

	[Header("State")]
	public bool isOpen = false;

	void Start()
	{
		CloseDropdown();
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GameSettings_Holder_Path,
			 () => CloseDropdown()
			 );
	}

	// Called by Header Button
	public void ToggleDropdown()
	{
		isOpen = !isOpen;
		optionsPanel.SetActive(isOpen);
	}

	// Called by Option Buttons
	public void SelectOption(string optionText)
	{
		selectedLabel.text = optionText;
		Debug.Log(gameObject.name + " Selected Option: " + selectedLabel.text);
		CloseDropdown();
	}

	void CloseDropdown()
	{
		isOpen = false;
		optionsPanel.SetActive(false);
	}

}
