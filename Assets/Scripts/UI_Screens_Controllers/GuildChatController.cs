using UnityEngine;

public class GuildChatController : MonoBehaviour
{
	void Start()
	{
		// Switch from Global Chat -> Guild Chat
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.GuildChat_Overlay_GuildChat__Button_Path,
			() =>
			{
				//UIManager.Instance.DeactivatePanel(
				//	UI_Library.Panel,
				//	UI_Library.GlobalChat_Overlay_Screen_Path
				//);

				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.GuildChat_Overlay_Screen_Path,
					false,
					false
				);
			}
		);
		// Switch from Guild Chat -> Global Chat
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.GuildChat_Overlay_GlobalChat_Button_Path,
			() =>
			{
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.GlobalChat_Overlay_Screen_Path,
					false,
					false
				);
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.GuildChat_Overlay_Screen_Path
				);
			}
		);
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildChatContent_Overlay_Interactable_Button_Path,
			 () => CloseOverlay()
			 );
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.GuildChat_Overlay_InputField_ChatMessage_Path,
			(value) =>
			{
				Debug.Log(value);
			});

	}

	private void CloseOverlay()
	{
		UIManager.Instance.	DeactivatePanel(
		UI_Library.Panel,
		UI_Library.GuildChat_Overlay_Screen_Path
		);
	}
}
