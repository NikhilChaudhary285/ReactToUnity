using UnityEngine;

public class InstanceBattleController : MonoBehaviour
{
	void Start()
	{
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.Quit_Instance_Battle_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			true,
			false
		));
	}

}