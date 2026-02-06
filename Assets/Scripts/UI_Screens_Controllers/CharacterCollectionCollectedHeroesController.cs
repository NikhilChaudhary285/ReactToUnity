using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Added for List
using TMPro;

public class CharacterCollectionCollectedHeroesController : MonoBehaviour
{
	[SerializeField] private Button highlightReferenceButton;
	[SerializeField] private Sprite hightlightSprite;
	[SerializeField] private Sprite normalSprite;

	// --- New Variables for Task 1 ---
	[Header("Main Hero Settings")]
	[SerializeField] private List<Button> registerButtons; // Drag your star buttons here in Inspector
	[SerializeField] private List<Image> starImages; // Drag your star buttons here in Inspector
	[SerializeField] private Sprite starActiveSprite;    // Gold Star
	[SerializeField] private Sprite starInactiveSprite;  // Grey Star
	private int currentMainHeroIndex = -1;             // Stores which hero is "Main"

	private void OnEnable()
	{
		highlightReferenceButton.image.sprite = hightlightSprite;
	}

	void Start()
	{
		// ... Existing Back Button Logic ...
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.CharacterCollectionCollectedHeroes_ScreenBack_Button_Path,
		() =>
		{
			UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.Gameplay_Hub_Environment_Overlay_Screen_Path, true, false);
			UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.PlayerProfile_Popup_Screen_Path, true, true);
		});

		// ... Existing Tab Navigation ...
		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.CollectedHeroes_CollectedHeroes_Button_Path,
			() => UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.CharacterCollection_CollectedHeroes_Screen_Path, true, false));

		UIManager.Instance.SetButtonListener(UI_Library.Button, UI_Library.CollectedHeroes_BattlePreparation_Button_Path,
			() => UIManager.Instance.ActivatePanel(UI_Library.Panel, UI_Library.CharacterCollection_BattlePreparation_Screen_Path, true, false));

		// --- New Logic: Initialize Star Buttons ---
		InitializeStarSelection();
	}

	private void InitializeStarSelection()
	{
		for (int i = 0; i < registerButtons.Count; i++)
		{
			int index = i; // Capture index for closure
			registerButtons[i].onClick.AddListener(() => SetAsMainHero(index));
		}
	}

	// Task 1 Logic: Radio Button functionality
	public void SetAsMainHero(int selectedIndex)
	{
		currentMainHeroIndex = selectedIndex;

		for (int i = 0; i < starImages.Count; i++)
		{
			if (i == currentMainHeroIndex)
			{
				starImages[i].sprite = starActiveSprite;
				registerButtons[i].GetComponentInChildren<TMP_Text>().text = "Registered";
				// LOGIC: Save this hero as the map character
				Debug.Log("Main Hero Set to Hero ID: " + i);
				// SaveToDatabase(heroStarButtons[i].name);
			}
			else
			{
				starImages[i].sprite = starInactiveSprite;
				registerButtons[i].GetComponentInChildren<TMP_Text>().text = "Register";
			}
		}
	}

	private void OnDisable()
	{
		highlightReferenceButton.image.sprite = normalSprite;
	}
}