using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

	GameController myUniqueController;
	GameObject mySoundButton;
	GameObject myMusicButton;
	GameObject myDifficultyButton;
	GameObject myTutorialButton;
	Text myGameVersion;
	GameMusicController myMusicController;

	// Use this for early initialization
	void Awake () {
		mySoundButton = GameObject.FindGameObjectWithTag("SoundOnOffButton");
		if (mySoundButton == null)
			Debug.LogError ("SOUND BUTTON NULL");

		myMusicButton = GameObject.FindGameObjectWithTag("MusicOnOffButton");
		if (myMusicButton == null)
			Debug.LogError ("MUSIC BUTTON NULL");

		myTutorialButton = GameObject.FindGameObjectWithTag("TutorialOnOffButton");
		if (myTutorialButton == null)
			Debug.LogError ("TUTORIAL BUTTON NULL");

		myDifficultyButton = GameObject.FindGameObjectWithTag("myDifficultyButton");
		if (myDifficultyButton == null)
			Debug.LogError ("DIFFICULTY BUTTON NULL");

		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError ("NULL myUniqueController!");
		}

		// Use this for initialization
		myMusicController = (GameMusicController)GameObject.FindObjectOfType (typeof(GameMusicController));
		if (myMusicController == null) {
			Debug.LogError ("NULL myMusicController!");
		}		

		// Set application version
		myGameVersion = Utils.GetTextWithName ("TheGameVersion");    
		myGameVersion.text = "Bottle Trap v" + Application.version;
	}

	// Use this for initialization
	void Start () {
		// Read preferences
		SettingsParameters.InitializeSettings();

		if (SettingsParameters.settingPlayMusic == true) {
			myMusicController.startTheMusic ();
		} else {
			myMusicController.stopTheMusic ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (SettingsParameters.settingPlaySound == true) {
			mySoundButton.GetComponentInChildren<Text> ().text = "SOUND ON";
		} else {
			mySoundButton.GetComponentInChildren<Text> ().text = "SOUND OFF";
		}

		if (SettingsParameters.settingPlayMusic == true) {
			myMusicButton.GetComponentInChildren<Text> ().text = "MUSIC ON";
		} else {
			myMusicButton.GetComponentInChildren<Text> ().text = "MUSIC OFF";
		}

		if (SettingsParameters.bTutorialMode == true) {
			myTutorialButton.GetComponentInChildren<Text> ().text = "ASK FOR TUTORIAL";
		} else {
			myTutorialButton.GetComponentInChildren<Text> ().text = "DON'T ASK FOR TUTORIAL";
		}

		if (SettingsParameters.settingGameDifficulty == SettingsParameters.GAME_DIFFICULTY_EASY) {
			myDifficultyButton.GetComponentInChildren<Text> ().text = "DIFFICULTY EASY";
		} else if (SettingsParameters.settingGameDifficulty == SettingsParameters.GAME_DIFFICULTY_NORMAL) {
			myDifficultyButton.GetComponentInChildren<Text> ().text = "DIFFICULTY NORMAL";
		} else if (SettingsParameters.settingGameDifficulty == SettingsParameters.GAME_DIFFICULTY_HARD) {
			myDifficultyButton.GetComponentInChildren<Text> ().text = "DIFFICULTY HARD";
		}
	}

	public void TutorialButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		myUniqueController.flipTutorialSetting ();

		SettingsParameters.SaveSettings ();
	}

	public void SoundButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		myUniqueController.flipSoundSetting ();

		SettingsParameters.SaveSettings ();
	}

	public void MusicButtonPressed() {
		myUniqueController.flipMusicSetting ();

		if (SettingsParameters.settingPlayMusic == true) {
			myMusicController.startTheMusic ();
		} else {
			myMusicController.stopTheMusic ();
		}

		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		SettingsParameters.SaveSettings ();
	}

	public void DifficultyButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		myUniqueController.flipDifficultySetting ();
		SettingsParameters.SaveSettings ();
	}

	public void ResetButtonPressed() {
		Debug.Log ("RESET BUTTON");
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		Utils.ConfirmationPopUp ();
	}

	public void YesYesButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_COIN);
		SettingsParameters.ResetSettings ();

		// Get rid of confirmation button
		Utils.ConfirmationPopUpRemove ();

		// Start initialization parameters
		Start ();
	}

	public void NoNoButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		Utils.ConfirmationPopUpRemove ();
	}

}
