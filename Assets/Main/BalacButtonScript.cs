using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
#endif

public class BalacButtonScript : MonoBehaviour {

	GameController myUniqueController;
	public Text userText;
	public Text AndroidOnlyText;
#if UNITY_ANDROID
	bool bDisconnectConfirmed = false;
#endif

	//************************************************************************************************
	// UNITY MANAGEMENT
	//************************************************************************************************

	// Use this for initialization
	void Start () {
		// Get User Text Object
		userText = Utils.GetTextWithName ("GGPS_User");
		AndroidOnlyText = Utils.GetTextWithName ("GGPS_AndroidOnly");

		// Get object for controller
		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError ("NULL myUniqueController!");
		}

#if UNITY_ANDROID
		// Connecto to GGPS
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();	
		AndroidOnlyText.enabled = false;
#else
		AndroidOnlyText.enabled = true;
#endif
	}

	void Update () {
		if (SceneManager.GetActiveScene().name == "StartMenu") {
#if UNITY_ANDROID
			// Set user text
			if (Social.localUser.authenticated) {
				userText.text = Social.localUser.userName;
			} else { 
				userText.text = "NO USER CONNECTED";
			}

			// Check if disconnect confirmed
			if ((Social.localUser.authenticated) && (bDisconnectConfirmed==true)) {
				// If connected, disconnect
				PlayGamesPlatform.Instance.SignOut();		
				bDisconnectConfirmed = false;
			}
#endif
		}
	}

	//************************************************************************************************
	// BUTTON MANAGEMENT
	//************************************************************************************************

	public void UnlimitedGameButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		myUniqueController.setGameMode (AllGameParameters.GAME_MODE_UNLIMITED);

		// Check if tutorial mode has to be pressented
		if (SettingsParameters.bTutorialMode == true) {
			SceneManager.LoadScene ("TutorialModeScreen");
		} else {
			myUniqueController.RemoveTutorialMode ();
			SceneManager.LoadScene ("WaitScreen");
		}
	}

	public void CampaignGameButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		myUniqueController.setGameMode (AllGameParameters.GAME_MODE_CAMPAIGN);

		// Check if tutorial mode has to be pressented
		if (SettingsParameters.bTutorialMode == true) {
			SceneManager.LoadScene ("TutorialModeScreen");
		} else {
			myUniqueController.RemoveTutorialMode ();
			SceneManager.LoadScene ("CampaignLevelSelection");
		}
	}

	/*public void ValidateGameButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		myUniqueController.setGameMode (AllGameParameters.GAME_MODE_CAMPAIGN);
		SceneManager.LoadScene ("WaitScreen");
	}*/

	public void ExitButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);

		// Save preferences
		SettingsParameters.SaveSettings();

		Application.Quit ();
	}

	public void MainMenuButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);

		// Save preferences
		SettingsParameters.SaveSettings ();

		SceneManager.LoadScene ("StartMenu");
	}


	public void ReadyButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("main");
	}

	public void SettingsButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("SettingsMenu");
	}

	public void RulesButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("MovesMenu");
	}

	public void MovesMenuNextButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("WallMoveMenu");
	}

	public void WallMoveNextButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("VolumeRulesMenu");
	}

	public void VolumeRulesNextButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("ColorRulesMenu");
	}

	public void ColorRulesNextButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("AcidRuleMenu");
	}

	public void AcidRuleNextButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SceneManager.LoadScene ("StartMenu");
	}

	public void GGPSButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);

#if UNITY_ANDROID
		if (Social.localUser.authenticated) 
		{
			// Call confirmation button
			Utils.ConfirmationPopUp();
		} else {
			// If not connected, connect
			Social.Active.localUser.Authenticate((bool success) => {
				// handle success or failure
				if (success) {
					Debug.Log ("LOGIN OK");
				} else {
					Debug.LogError ("LOGIN KO");
				}
			});		
		}
#endif
	}

	public void AchievementsButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);

#if UNITY_ANDROID
		Debug.Log ("showTrophesPressed BUTTON PRESSED");
		if (Social.localUser.authenticated) {
			Social.ShowAchievementsUI ();
		}		
#endif
}
		
	public void HighScoresButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);

#if UNITY_ANDROID
		Debug.Log ("showScoresPressed BUTTON PRESSED");
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI ();
		}
#endif
	}

	public void YesButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
#if UNITY_ANDROID
		bDisconnectConfirmed = true;
#endif
		Utils.ConfirmationPopUpRemove ();
	}

	public void NoButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
#if UNITY_ANDROID
		bDisconnectConfirmed = false;
#endif
		Utils.ConfirmationPopUpRemove ();
	}
}
