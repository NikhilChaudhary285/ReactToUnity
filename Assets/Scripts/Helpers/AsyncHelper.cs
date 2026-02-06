using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// AsyncHelper
/// --------------------------------------------------
/// Centralized utility for delayed, repeated, and condition-based execution.
/// Safe for MVP usage and reusable across UI, gameplay, quests, tutorials.
/// </summary>
public class AsyncHelper : MonoBehaviour
{
	#region Singleton

	private static AsyncHelper instance;

	public static AsyncHelper Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindFirstObjectByType<AsyncHelper>();
				if (instance == null)
				{
					GameObject obj = new GameObject("UIManager");
					instance = obj.AddComponent<AsyncHelper>();
				}
			}
			return instance;
		}
	}

	#endregion

	#region Repetitive Call (Initial + Repeat)

	/// <summary>
	/// Calls an action immediately, then after initial delay,
	/// then repeatedly until cancelCondition becomes true.
	/// </summary>
	public static void RepetitiveCall(
		Action action,
		float initialCallDelay,
		float repeatDelay,
		Func<bool> cancelCondition
	)
	{
		action?.Invoke();
		Instance.StartCoroutine(RepetitiveCoroutine());

		IEnumerator RepetitiveCoroutine()
		{
			yield return new WaitForSeconds(initialCallDelay);
			action?.Invoke();

			while (cancelCondition == null || !cancelCondition())
			{
				yield return new WaitForSeconds(repeatDelay);
				action?.Invoke();
			}
		}
	}

	#endregion

	#region Call After Delay

	/// <summary>
	/// Calls an action once after a delay.
	/// Optional cancel condition can stop execution.
	/// </summary>
	public static void CallAfterDelay(
		Action action,
		float delay,
		Func<bool> cancelCondition = null
	)
	{
		Instance.StartCoroutine(DelayCoroutine());

		IEnumerator DelayCoroutine()
		{
			float startTime = Time.time;

			while (Time.time < startTime + delay)
			{
				if (cancelCondition != null && cancelCondition())
					yield break;

				yield return null;
			}

			action?.Invoke();
		}
	}

	#endregion

	#region Call After Condition

	/// <summary>
	/// Calls an action once a condition becomes true.
	/// Optional cancel condition supported.
	/// </summary>
	public static void CallAfterCondition(
		Action action,
		Func<bool> condition,
		Func<bool> cancelCondition = null
	)
	{
		Instance.StartCoroutine(ConditionCoroutine());

		IEnumerator ConditionCoroutine()
		{
			while (!condition())
			{
				if (cancelCondition != null && cancelCondition())
					yield break;

				yield return new WaitForSeconds(0.25f);
			}

			action?.Invoke();
		}
	}

	#endregion

	#region Async Invoke Repeating (Task-based)

	/// <summary>
	/// Repeats an action using async/await until cancel condition is met.
	/// Useful for non-Unity-thread dependent logic.
	/// </summary>
	public static async void InvokeRepeatingAsync(
		Action action,
		float repeatTime,
		Func<bool> cancelCondition = null
	)
	{
		int delayMs = Mathf.RoundToInt(repeatTime * 1000f);

		while (true)
		{
			action?.Invoke();

			if (cancelCondition != null && cancelCondition())
				break;

			await Task.Delay(delayMs);
		}
	}

	#endregion
}
