using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private CanvasGroup splashCanvas;

	[Header("Timing")]
	[SerializeField] private float fadeInDuration = 1.2f;
	[SerializeField] private float holdDuration = 0.8f;
	[SerializeField] private float fadeOutDuration = 1.2f;

	private void Start()
	{
		StartCoroutine(SplashSequence());
	}

	private IEnumerator SplashSequence()
	{
		// Ensure splash visible
		splashCanvas.alpha = 0f;
		splashCanvas.blocksRaycasts = true;

		// Fade In
		yield return Fade(0f, 1f, fadeInDuration);

		// Hold
		yield return new WaitForSeconds(holdDuration);

		// Activate GameDataLoading BEFORE fade-out
		UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.GameDataLoading_Screen_Path,
			true,
			false
		);

		// Small delay so panel is ready behind splash
		yield return new WaitForSeconds(0.05f);

		// Fade Out Splash (GameDataLoading visible underneath)
		yield return Fade(1f, 0f, fadeOutDuration);

		// Disable splash completely
		splashCanvas.blocksRaycasts = false;
		gameObject.SetActive(false);
	}

	private IEnumerator Fade(float from, float to, float duration)
	{
		float t = 0f;

		while (t < duration)
		{
			t += Time.deltaTime;
			splashCanvas.alpha = Mathf.Lerp(from, to, t / duration);
			yield return null;
		}

		splashCanvas.alpha = to;
	}
}
