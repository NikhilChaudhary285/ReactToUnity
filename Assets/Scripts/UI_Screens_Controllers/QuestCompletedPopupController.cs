using UnityEngine;

public class QuestCompletedPopupController : MonoBehaviour
{	
	private void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.QuestCompleteScreen_Back_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.QuestComplete_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.ClaimRewards_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.QuestComplete_Popup_Screen_Path
				);
			});
	}

}
