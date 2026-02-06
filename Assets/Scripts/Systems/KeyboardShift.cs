using UnityEngine;
using TMPro;

public class KeyboardShift : MonoBehaviour
{
	public RectTransform uiContainer; // Drag your Login Box here
	private Vector2 originalPosition;

	void Start()
	{
		originalPosition = uiContainer.anchoredPosition;
	}

	void Update()
	{
		if (TouchScreenKeyboard.visible)
		{
			// Get keyboard height in normalized screen space
			float keyboardHeight = GetKeyboardHeight();
			// Move UI up by the height of the keyboard
			uiContainer.anchoredPosition = new Vector2(originalPosition.x, originalPosition.y + (keyboardHeight / 2));
		}
		else
		{
			// Return to original position when closed
			uiContainer.anchoredPosition = originalPosition;
		}
	}

	private float GetKeyboardHeight()
	{
#if UNITY_ANDROID
		using (AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			AndroidJavaObject View = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getWindow").Call<AndroidJavaObject>("getDecorView");
			Rect rect = new Rect();
			View.Call("getWindowVisibleDisplayFrame", rect);
			return Screen.height - rect.height; // Returns height in pixels
		}
#else
        return 0;
#endif
	}
}