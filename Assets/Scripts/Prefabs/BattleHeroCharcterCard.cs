using UnityEngine;
using UnityEngine.UI;

public class BattleHeroCharacterCard : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField] private Toggle selectionToggle;
	[SerializeField] private Image cardImage;

	// Reference to the main controller to check limits and update counters
	[SerializeField] private CharacterCollectionBattlePreparationController controller;

	[Header("Sprites")]
	[SerializeField] private Sprite selectedSprite;
	[SerializeField] private Sprite unselectedSprite;

	private void Awake()
	{
		// Listen to toggle change
		selectionToggle.onValueChanged.AddListener(OnToggleValueChanged);

		// Ensure default state
		SetSelected(false);
	}

	private void OnDestroy()
	{
		selectionToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
	}

	/// <summary>
	/// Called when toggle is clicked
	/// </summary>
	private void OnToggleValueChanged(bool isOn)
	{
		// TASK 3: Selection Guard Logic
		// If the user tries to turn the toggle ON, check if the team is already full
		if (isOn && controller != null && controller.IsTeamFull)
		{
			// Revert the toggle without triggering this listener again
			selectionToggle.SetIsOnWithoutNotify(false);
			Debug.LogWarning("Selection blocked: Team is already full (3/3).");
			return;
		}

		// Update visuals
		UpdateVisuals(isOn);

		// TASK 2: Notify the controller to update the dynamic counter (1/3, 2/3, etc.)
		if (controller != null)
		{
			controller.OnHeroSelected(isOn);
		}
	}

	/// <summary>
	/// Select / Unselect card via code
	/// </summary>
	public void SetSelected(bool isSelected)
	{
		// We use SetIsOnWithoutNotify if we want to set state without triggering logic, 
		// but here we usually want the listener to fire to update the controller.
		selectionToggle.isOn = isSelected;
		UpdateVisuals(isSelected);
	}

	private void UpdateVisuals(bool isSelected)
	{
		if (cardImage != null)
		{
			cardImage.sprite = isSelected ? selectedSprite : unselectedSprite;
		}
	}

	/// <summary>
	/// Call this from Button OnClick
	/// </summary>
	public void OnCardClicked()
	{
		// This simply flips the toggle, which triggers OnToggleValueChanged
		selectionToggle.isOn = !selectionToggle.isOn;
	}
}