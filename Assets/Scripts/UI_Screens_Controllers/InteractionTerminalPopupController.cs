using UnityEngine;

public class InteractionTerminalPopupController : MonoBehaviour
{
	private void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.InteractionTerminalScreen_Back_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.InteractionTerminal_Popup_Screen_Path
				);
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
					false, false
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.Contextual_CTA_Button_Path,
			() =>
			{
				Debug.Log("Clicked: InteractionTerminal_Contextual_CTA_Button");
				//UIManager.Instance.DeactivateAllPanels();

				//UIManager.Instance.DeactivatePanel(
				//	UI_Library.Panel,
				//	UI_Library.InteractionTerminal_Popup_Screen_Path
				//);
				//UIManager.Instance.ActivatePanel(
				//	UI_Library.Panel,
				//	UI_Library.MainMenu_Screen_Path,
				//	false, false
				//);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.UpgradeGearReturn_Button_Path,
			() =>
			{
				Debug.Log("Clicked: InteractionTerminal_UpgradeGearReturn_Button");
				//UIManager.Instance.DeactivateAllPanels();

				//UIManager.Instance.DeactivatePanel(
				//	UI_Library.Panel,
				//	UI_Library.InteractionTerminal_Popup_Screen_Path
				//);
				//UIManager.Instance.ActivatePanel(
				//	UI_Library.Panel,
				//	UI_Library.MainMenu_Screen_Path,
				//	false, false
				//);
			});
	}

}
