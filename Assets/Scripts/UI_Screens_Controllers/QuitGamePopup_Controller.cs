using UnityEngine;

public class QuitGamePopup_Controller : MonoBehaviour
{
	void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.QuitGameScreen_Back_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.QuitGamePopup_No_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.QuitGamePopup_Yes_Button_Path,
			() => Application.Quit()
		);

	}
}
