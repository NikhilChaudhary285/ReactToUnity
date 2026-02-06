using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.MainMenu_Back_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.HUBS_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.SelectHub_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.GUILD_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GuildLobby_MyGuild_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.LEADERBOARD_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Leaderboard_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.REDEEMCODE_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.RedeemCode_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.HERO_GALLERY_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.CharacterCollection_CollectedHeroes_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.SETTINGS_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GameSettings_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.MainMenu_StartGame_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			true,
			false
		));
	}

}
