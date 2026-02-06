using UnityEngine;

public class QuestAcceptedPopupController : MonoBehaviour
{
	private void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.QuestAcceptedScreen_Back_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.QuestAccepted_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.QuestAccepted_TrackQuest_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.QuestAccepted_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.QuestAccepted_Continue_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.QuestAccepted_Popup_Screen_Path
				);
			});
	}

}
