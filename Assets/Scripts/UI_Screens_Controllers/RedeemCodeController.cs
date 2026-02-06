using UnityEngine;

public class RedeemCodeController : MonoBehaviour
{
	void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.RedeemCodeScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.InputField_RedeemCode_Path,
			(value) =>
			{
				Debug.Log(value);
			});
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.RedeemCode_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.RedeemCodeSuccess_Screen_Path,
			true,
			true
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.RedeemCode_Back_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
	}
}
