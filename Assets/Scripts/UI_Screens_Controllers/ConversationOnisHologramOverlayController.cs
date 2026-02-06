using UnityEngine;

public class ConversationOnisHologramOverlayController : MonoBehaviour
{
	private void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.ConversationOnisHologram_Skip_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivateAllPanels();

				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.ConversationWithOnisHologram_Overlay_Screen_Path
				);
				//UIManager.Instance.ActivatePanel(
				//	UI_Library.Panel,
				//	UI_Library.MainMenu_Screen_Path,
				//	false, false
				//);
			});
	}

}
