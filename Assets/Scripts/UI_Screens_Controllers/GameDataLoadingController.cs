using UnityEngine;
using System.Collections;

public class GameDataLoadingController : MonoBehaviour
{
	[Header("Scene Settings")]
	[SerializeField] private float minimumDisplayTime = 3f;
	[SerializeField] private float fakeLoadDuration = 2.5f;

	private float realProgress;
	private float displayedProgress;
	private float timer;

	private UnityEngine.UI.Slider progressSlider;

	private void Start()
	{
		progressSlider = UIManager.Instance.GetSlider(
			UI_Library.Slider,
			UI_Library.GameDataLoadingProgress_Slider_Path
		);

		Debug.Log("Slider Found: " + progressSlider.name);

		StartCoroutine(LoadFlow());
	}

	private IEnumerator LoadFlow()
	{
		// Step 1: Connecting
		UIManager.Instance.SetTMPTextContent(
			UI_Library.TMP_Text,
			UI_Library.Checking_data_updates_Text_Path,
			"Connecting to servers..."
		);

		yield return new WaitForSeconds(0.8f);

		// Step 2: Start fake backend loading
		StartCoroutine(FakeBackendLoading());

		UIManager.Instance.SetTMPTextContent(
			UI_Library.TMP_Text,
			UI_Library.Checking_data_updates_Text_Path,
			"Loading game data..."
		);

		// Step 3: Progress loop
		while (realProgress < 1f || timer < minimumDisplayTime)
		{
			timer += Time.deltaTime;

			displayedProgress = Mathf.MoveTowards(
				displayedProgress,
				realProgress,
				Time.deltaTime * 0.6f
			);

			progressSlider.value = displayedProgress;
			yield return null;
		}

		// Step 4: Finish
		progressSlider.value = 1f;

		UIManager.Instance.SetTMPTextContent(
			UI_Library.TMP_Text,
			UI_Library.Checking_data_updates_Text_Path,
			"Entering world..."
		);

		yield return new WaitForSeconds(0.4f);

		// Step 5: Activate next panel
		UIManager.Instance.ActivatePanel(
			UI_Library.Panel,
			UI_Library.Login_Screen_Path,
			true,
			false
		);
	}

	/// <summary>
	/// Simulates MMO-style backend loading
	/// </summary>
	private IEnumerator FakeBackendLoading()
	{
		float elapsed = 0f;

		while (elapsed < fakeLoadDuration)
		{
			elapsed += Time.deltaTime;
			realProgress = Mathf.Clamp01(elapsed / fakeLoadDuration);
			yield return null;
		}

		realProgress = 1f;
	}
}
