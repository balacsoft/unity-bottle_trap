using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialModeController : MonoBehaviour {

	GameController myUniqueController;

	// Use this for initialization
	void Awake () {
		// Get object for controller
		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError ("NULL myUniqueController!");
		}	
	}
	
	// Is called when YES button is pressed for tutorial mode
	public void GameYesButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);

		// We set tutorial mode for the next game
		myUniqueController.SetTutorialMode ();

		// Start the game
		SceneManager.LoadScene ("TutorialMain");
	}

	public void GameNoButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		// We set tutorial mode for the next game
		myUniqueController.RemoveTutorialMode ();

		// Start the game
		StartTheGameNow();
	}

	public void MainMenuButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("StartMenu");
	}

	private void StartTheGameNow() {
		if (myUniqueController.getGameMode () == AllGameParameters.GAME_MODE_CAMPAIGN) {
			SceneManager.LoadScene ("CampaignLevelSelection");
		} else {
			SceneManager.LoadScene ("WaitScreen");
		}
	}
}
