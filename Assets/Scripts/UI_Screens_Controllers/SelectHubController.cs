using UnityEngine;

public class SelectHubController : MonoBehaviour
{
    void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.SelectHub_ScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.SelectHub_BackToMainMenu_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.SelectHub_EnterHub_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			true,
			false
		));
	}

}
