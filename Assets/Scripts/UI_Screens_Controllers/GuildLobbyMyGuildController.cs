using UnityEngine;

public class GuildLobbyMyGuildController : MonoBehaviour
{
    void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_MyGuild_ScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_MyGuild_MyGuild_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_MyGuild_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_MyGuild_CreateGuild_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_CreateGuild_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_MyGuild_JoinGuild_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_JoinGuild_Screen_Path,
			true,
			false
		));
	}

}
