using UnityEngine;

public class GameSettingsController : MonoBehaviour
{
	[SerializeField] private Sprite soundOnSprite;
	[SerializeField] private Sprite soundOffSprite;

	void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GameSettingsScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GameSettings_Save_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetSliderListener(UI_Library.Slider, UI_Library.Music_Slider_Path, (value) =>
		{
			Debug.Log("MusicSliderValue: " + value);
		});
		UIManager.Instance.SetSliderListener(UI_Library.Slider, UI_Library.SFX_Slider_Path, (value) =>
		{
			Debug.Log("SFXSliderValue: " + value);
		});
		UIManager.Instance.SetTMP_DropdownListener(
			UI_Library.TMP_Dropdown,
			UI_Library.GraphicQuality_Dropdown_Path,
			(index) =>
			{
				var dropdown = UIManager.Instance.GetTMP_Dropdown(
					UI_Library.TMP_Dropdown,
					UI_Library.GraphicQuality_Dropdown_Path
				);

				string selectedOption = dropdown.options[index].text;
				Debug.Log("Graphic Quality Selected: " + selectedOption);
		});
		UIManager.Instance.SetTMP_DropdownListener(
			UI_Library.TMP_Dropdown,
			UI_Library.LanguageSettings_Dropdown_Path,
			(index) =>
			{
				var dropdown = UIManager.Instance.GetTMP_Dropdown(
					UI_Library.TMP_Dropdown,
					UI_Library.LanguageSettings_Dropdown_Path
				);

				string selectedOption = dropdown.options[index].text;
				Debug.Log("Language Selected: " + selectedOption);
		});
		UIManager.Instance.SetToggleListener(
			UI_Library.Toggle,
			UI_Library.Sound_Toggle_Path,
			(isOn) =>
			{
				// Getting the image first
				var img = UIManager.Instance.GetImage(UI_Library.Image, UI_Library.Sound_Toggle_Image_Path);

				// Swap sprite based on toggle state
				if (img != null)
					img.sprite = isOn ? soundOnSprite : soundOffSprite;
		});
	}

}
