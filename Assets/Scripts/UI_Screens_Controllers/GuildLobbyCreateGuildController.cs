using UnityEngine;

public class GuildLobbyCreateGuildController : MonoBehaviour
{
	void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_CreateGuild_ScreenBack_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.MainMenu_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_CreateGuild_MyGuild_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_MyGuild_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_CreateGuild_CreateGuild_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_CreateGuild_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GuildLobby_CreateGuild_JoinGuild_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_JoinGuild_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.GuildLobby_CreateGuild_InputField_Path,
			(value) =>
			{
				Debug.Log(value);
			});
		UIManager.Instance.SetTMP_InputFieldListener(
			UI_Library.TMP_InputField,
			UI_Library.GuildLobby_CreateGuildDescription_InputField_Path,
			(value) =>
			{
				Debug.Log(value);
			});
	}
}
