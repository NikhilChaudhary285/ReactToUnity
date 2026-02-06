using UnityEngine;

public class MemoryFlashPopupController : MonoBehaviour
{
	private void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.MemoryFlash_Skip_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.MemoryFlash_Message_Popup_Screen_Path
				);
			});
	}

}
