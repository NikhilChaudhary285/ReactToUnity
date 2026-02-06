using UnityEngine;

public class SignupController : MonoBehaviour
{
    void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.SignupScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Signup_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.LoginNow_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Signup_Screen_QuitGame_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.QuitGame_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.Signup_InputField_Email_Path,
			(value) =>
			{
				Debug.Log(value);
			});
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.Signup_InputField_Password_Path,
			(value) =>
			{
				Debug.Log(value);
			});
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.Signup_InputField_ConfirmPassword_Path,
			(value) =>
			{
				Debug.Log(value);
			});

	}

}
