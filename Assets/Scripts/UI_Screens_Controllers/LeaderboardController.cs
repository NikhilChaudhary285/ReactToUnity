using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class LeaderboardController : MonoBehaviour
{
    void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Leaderboard_ScreenBack_Button_Path,
		() =>
		{
			UIManager.Instance.ActivatePanel(
				UI_Library.Panel,
				UI_Library.MainMenu_Screen_Path,
				true,
				false
			);

			//UIManager.Instance.ActivatePanel(
			//	UI_Library.Panel,
			//	UI_Library.PlayerProfile_Popup_Screen_Path,
			//	true,
			//	true
			//);
		});
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.InputField_Leaderboard_Path,
			(value) =>
			{
				Debug.Log(value);
			});
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Leaderboard_Search_Button_Path,
			() => Debug.Log("Clicked: Leaderboard_Search_Button")
			);
	}

}
