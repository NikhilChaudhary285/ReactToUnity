using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCollectionBattlePreparationController : MonoBehaviour
{
	[SerializeField] private Button highlightReferenceButton;
	[SerializeField] private Sprite hightlightSprite;
	[SerializeField] private Sprite normalSprite;

	[Header("Task 2 & 3: Selection Logic")]
	[SerializeField] private TMP_Text yourSelectedHeroesCount_Text;
	[SerializeField] private Button saveTeamButton;

	private int currentSelectionCount = 0;
	private const int MAX_TEAM_SIZE = 3;

	// --- ADDED FOR TASK 3 ---
	// Public property so the Hero Card can check the limit before toggling
	public bool IsTeamFull => currentSelectionCount >= MAX_TEAM_SIZE;

	private void OnEnable()
	{
		highlightReferenceButton.image.sprite = hightlightSprite;
		UpdateCounterUI();
	}

	void Start()
	{
		// UI Navigation Listeners
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.BattlePreparation_CharacterCollectionScreenBack_Button_Path,
		() => {
			UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path, true, false);
			UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.PlayerProfile_Popup_Screen_Path, true, true);
		});

		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.BattlePreparation_CollectedHeroes_Button_Path,
			() => UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.CharacterCollection_CollectedHeroes_Screen_Path, true, false));

		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.BattlePreparation_BattlePreparation_Button_Path,
			() => UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.CharacterCollection_BattlePreparation_Screen_Path, true, false));

		// TASK 3: Save Team Logic
		saveTeamButton.onClick.AddListener(() => {
			if (currentSelectionCount == MAX_TEAM_SIZE)
			{
				Debug.Log("Team Saved Successfully! Updating Database...");
				// Add your DB save logic here
			}
		});
	}

	// TASK 2 & 3: Selection Guard Logic
	public void OnHeroSelected(bool isBeingAdded)
	{
		if (isBeingAdded)
		{
			if (currentSelectionCount < MAX_TEAM_SIZE)
			{
				currentSelectionCount++;
			}
			else
			{
				// This shouldn't be reached if the Card script checks IsTeamFull first
				Debug.LogWarning("Selection blocked: Team is already full.");
				return;
			}
		}
		else
		{
			if (currentSelectionCount > 0)
			{
				currentSelectionCount--;
			}
		}

		UpdateCounterUI();
	}

	private void UpdateCounterUI()
	{
		if (yourSelectedHeroesCount_Text != null)
		{
			yourSelectedHeroesCount_Text.text = $"Heroes Selected: {currentSelectionCount} / {MAX_TEAM_SIZE}";
		}

		// Button is only clickable if exactly 3 heroes are selected
		if (saveTeamButton != null)
		{
			saveTeamButton.interactable = (currentSelectionCount == MAX_TEAM_SIZE);
		}
	}

	private void OnDisable()
	{
		highlightReferenceButton.image.sprite = normalSprite;
	}
}