using UnityEngine;
using UnityEngine.Rendering.Universal;

public class URPPostProcessingToggle : MonoBehaviour
{
	private UniversalAdditionalCameraData cameraData;

	void Awake()
	{
		Camera cam = Camera.main;

		if (cam != null)
		{
			cameraData = cam.GetUniversalAdditionalCameraData();
		}
	}

	public void ToggleBlurEffect()
	{
		if (cameraData != null)
		{
			cameraData.renderPostProcessing = !cameraData.renderPostProcessing;
		}
	}
}
