using UnityEngine;

public class QuestsBoardController : MonoBehaviour
{
    void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.QuestsBoard_ScreenBack_Button_Path,
			 () => UIManager.Instance.ActivatePanel(
			 UI_Library.Panel,
			 UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			 true,
			 false
		 ));
	}

}
