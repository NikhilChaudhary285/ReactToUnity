using UnityEngine;

public class UnityBridge : MonoBehaviour
{
	// This function name MUST match what we call in React Native
	public void HandleRNMessage(string message)
	{
		Debug.Log("React Native says: " + message);

		if (message == "ping")
		{
			// Do something cool in your scene!
			Debug.Log("Unity is alive!");
		}
	}
}