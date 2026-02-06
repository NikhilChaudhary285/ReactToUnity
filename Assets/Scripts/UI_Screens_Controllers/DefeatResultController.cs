using UnityEngine;

public class DefeatResultController : MonoBehaviour
{
	void Start()
	{

		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.DefeatResult_Retry_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(UI_Library.Panel,
					UI_Library.DefeatResult_Screen_Path);

				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.InstanceBattle_Screen_Path,
					true,
					false
				);
		});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.DefeatResult_ReturnToHub_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(UI_Library.Panel,
					UI_Library.DefeatResult_Screen_Path);

				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
					true,
					false
				);
		});
	}
}
