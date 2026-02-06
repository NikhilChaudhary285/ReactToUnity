using UnityEngine;

public class PlayerProfilePopupController : MonoBehaviour
{
	private void OnEnable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();
	private void OnDisable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();

	void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.PlayerProfile_Back_Button_Path,
			 () => UIManager.Instance.ActivatePanel(
			 UI_Library.Panel,
			 UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			 true,
			 false
		 ));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.PlayerProfile_SelectCharacter_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.CharacterCollection_CollectedHeroes_Screen_Path,
			true,
			false
		));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.PlayerProfile_ViewLeaderboard_Button_Path,
			 () => UIManager.Instance.ActivatePanel(
			 UI_Library.Panel,
			 UI_Library.Leaderboard_Screen_Path,
			 true,
			 false
		 ));
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.PlayerProfile_ReturnToHub_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			true,
			false
		));
	}
}
