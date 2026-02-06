using UnityEngine;

public class TradingStoreConfirmationTradePopupController : MonoBehaviour
{
    void Start()
    {
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.TradingStoreConfirmation_Yes_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(UI_Library.Panel,
					UI_Library.TradingStoreConfirmationTrade_Popup_Screen_Path);
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
					true,
					false
				);
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.TradingStore_Popup_Screen_Path,
					true,
					true
				);
		});
		UIManager.Instance.SetButtonListener(
			UI_Library.Button,
			UI_Library.TradingStoreConfirmation_No_Button_Path,
			() =>
			{
				UIManager.Instance.DeactivatePanel(UI_Library.Panel,
					UI_Library.TradingStoreConfirmationTrade_Popup_Screen_Path);
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path,
					true,
					false
				);
				UIManager.Instance.ActivatePanel(
					UI_Library.Panel,
					UI_Library.TradingStore_Popup_Screen_Path,
					true,
					true
				);
			});
	}

}
