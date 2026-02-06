using UnityEngine;

public class VictoryResultController : MonoBehaviour
{
	void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.VictoryResult_ReturnToHub_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(UI_Library.Panel,
					UI_Library.VictoryResult_Screen_Path);

				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
					true,
					false
				);
		});
	}
}
