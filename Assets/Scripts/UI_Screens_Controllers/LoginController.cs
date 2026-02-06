using UnityEngine;

public class LoginController : MonoBehaviour
{
	private void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.LoginScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Signup_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Login_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.RegisterNow_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Signup_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Login_Screen_QuitGame_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.QuitGame_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.Login_InputField_Username_Path,
			(value) =>
			{
				Debug.Log(value);
			});
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.Login_InputField_Password_Path,
			(value) =>
			{
				Debug.Log(value);
			});
	}

}
