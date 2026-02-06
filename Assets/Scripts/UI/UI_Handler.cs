using UnityEngine;

public class UI_Handler : MonoBehaviour
{
	public static UI_Handler Instance;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	private void Start()
	{
		// Only open splash
		UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Splash_Screen_Path,
			true,
			false
		);
	}

	public void OpenUrl(string url)
	{
		Application.OpenURL(url);
	}
}
