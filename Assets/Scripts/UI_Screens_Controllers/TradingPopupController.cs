using UnityEngine;

public class TradingPopupController : MonoBehaviour
{
	private void OnEnable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();
	private void OnDisable() => Camera.main.GetComponent<URPPostProcessingToggle>().ToggleBlurEffect();

	void Start()
    {
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.TradingStoreScreen_Back_Button_Path,
			() => UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
			true,
			true
		));
	}

}
