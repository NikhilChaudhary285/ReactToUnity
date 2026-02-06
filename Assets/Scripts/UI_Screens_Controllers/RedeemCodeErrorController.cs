using UnityEngine;

public class RedeemCodeErrorController : MonoBehaviour
{
	private void OnEnable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();
	private void OnDisable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();

	void Start()
	{
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.RedeemErrorCodeScreenBack_Button_Path,
			() =>
			{
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.RedeemCode_Screen_Path,
					false, false
				);
				UIManager.Instance.DeactivatePanel(
					UI_Library.Panel,
					UI_Library.RedeemErrorCode_Screen_Path
				);
		});
	}
}
