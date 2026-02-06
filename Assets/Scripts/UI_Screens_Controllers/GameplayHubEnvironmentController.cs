using UnityEngine;

public class GameplayHubEnvironmentController : MonoBehaviour
{
    void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.PlayerProfile_Icon_Button_Path,
			() =>
			{
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
					true,
					false
				);

				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.PlayerProfile_Popup_Screen_Path,
					true,
					true
				);
			});
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuidOpening_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_CreateGuild_Screen_Path,
			true,
			false	
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.QuestOpening_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.QuestsBoard_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.TradingOpening_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.TradingStore_Popup_Screen_Path,
			true,
			true
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.JaxTraderInteractionTerminalTradingOpening_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.InteractionTerminal_Popup_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Chat_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildChat_Overlay_Screen_Path,
			false,
			true
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Game_Hub_Env_Settings_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GameSettings_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.ExitHub_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
	}
}
