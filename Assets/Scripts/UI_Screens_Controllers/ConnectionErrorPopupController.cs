using UnityEngine;

public class ConnectionErrorPopupController : MonoBehaviour
{
	private void OnEnable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();
	private void OnDisable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();

	void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.ConnectionErrorPopupScreen_Back_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.ConnectionError_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.ConnectionError_ExitToMainMenu_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.ConnectionError_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.ConnectionError_Retry_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.ConnectionError_Popup_Screen_Path
				);
			});

	}
}
