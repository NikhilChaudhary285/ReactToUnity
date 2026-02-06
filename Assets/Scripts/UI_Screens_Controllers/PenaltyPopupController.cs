using UnityEngine;

public class PenaltyPopupController : MonoBehaviour
{
	private void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.PenaltyScreen_Back_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.Penalty_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.Penalty_Retry_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.Penalty_Popup_Screen_Path
				);
			});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.Penalty_ReturnToHub_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.Penalty_Popup_Screen_Path
				);
			});
	}
}
