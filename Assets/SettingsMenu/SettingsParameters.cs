using UnityEngine;
using System.Collections;

public class SettingsParameters : MonoBehaviour {

	//////////////////////////////////////////////////////////////////////////
	// Game Difficulties
	public const int GAME_DIFFICULTY_HARD 		= 1;
	public const int GAME_DIFFICULTY_NORMAL 	= 2;
	public const int GAME_DIFFICULTY_EASY 		= 3;

	// Number of level in Campaign mode
	public const int LEVEL_NUMBER 				= 15;

	//////////////////////////////////////////////////////////////////////////
	// Boolean variables for sound and music settings
	public static bool settingPlaySound;
	public static bool settingPlayMusic;
	// Integer variable for difficulty (1=hard, 2=normal, 3=easy)
	public static int settingGameDifficulty = 2;	
	// Currently reached World
	public static int currentlyReachedLevel = 1;
	// Number of stars for current level
	public static int[] starsForLevel;

	// GOD MODE (for debug)
	public static bool bGodMode = false;

	// This singleton on this class
	public static SettingsParameters mySettingsParameters;

	// Tutorial Mode (if TRUE, we ask for it, otherwise not)
	public static bool bTutorialMode = true;

	//////////////////////////////////////////////////////////////////////////

	//////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////

	//////////////////////////////////////////////////////////////////////////
	// Set all parameters at awake of the scene
	void Awake () {
		if (mySettingsParameters == null) {
			// Create the manager
			DontDestroyOnLoad (gameObject);
			mySettingsParameters = this;
		} else if (mySettingsParameters != this) {
			// Destroy it to have always only one manager (Singleton Design Pattern)
			Destroy (gameObject);
		}
	}

	//////////////////////////////////////////////////////////////////////////
	// Initialize the settings from the persistence (file or registry)
	public static void InitializeSettings() {
		// Get tutorial mode
		int pTutorialMode = PlayerPrefs.GetInt ("TUTORIAL MODE",1);

		// Get stored values (true if absent)
		int psound = PlayerPrefs.GetInt ("SETTING PLAY SOUND",1);
		int pmusic = PlayerPrefs.GetInt ("SETTING PLAY MUSIC",1);
		// Get Game Difficulty (2 = normal by default)
		settingGameDifficulty = PlayerPrefs.GetInt ("SETTING GAME DIFFICULTY", 2); 
		// Currently Reached world
		currentlyReachedLevel = PlayerPrefs.GetInt ("CURRENT LEVEL", 0); 

		// Get all stars
		starsForLevel = new int[LEVEL_NUMBER];
		for (int i = 0; i < LEVEL_NUMBER; i++) {
			starsForLevel[i] = PlayerPrefs.GetInt ("STARS FOR LEVEL " + i, 0);
		}

		// Set read values
		if (pTutorialMode == 1) 
			bTutorialMode = true;
		else
			bTutorialMode = false;
		
		if (psound == 1) 
			settingPlaySound = true;
		else
			settingPlaySound = false;
		
		if (pmusic == 1) 
			settingPlayMusic = true;
		else
			settingPlayMusic = false;

//		Debug.Log ("READ Settings-music="+settingPlayMusic+"-sound="+settingPlaySound);
	}

	//////////////////////////////////////////////////////////////////////////
	// Save the settings in the persistence (file or registry)
	public static void SaveSettings () {
		int psound;
		int pmusic;
		int pTutorialMode;

		// Set read values
		if (settingPlaySound == true) 
			psound = 1;
		else
			psound = 0;
		
		if (settingPlayMusic == true) 
			pmusic = 1;
		else
			pmusic = 0;

		if (bTutorialMode == true) 
			pTutorialMode = 1;
		else
			pTutorialMode = 0;

		// Set tutorial mode
		PlayerPrefs.SetInt ("TUTORIAL MODE",pTutorialMode);
		// Set sound parameters
		PlayerPrefs.SetInt ("SETTING PLAY SOUND",psound);
		PlayerPrefs.SetInt ("SETTING PLAY MUSIC",pmusic);
		// Set Game Difficulty
		PlayerPrefs.SetInt ("SETTING GAME DIFFICULTY", settingGameDifficulty); 
		// Currently Reached world
		PlayerPrefs.SetInt ("CURRENT LEVEL", currentlyReachedLevel); 

		// Set all stars
		for (int i = 0; i < LEVEL_NUMBER; i++) {
			PlayerPrefs.SetInt ("STARS FOR LEVEL " + i, starsForLevel [i]);
		}

		// Save parameters
		PlayerPrefs.Save();
	}

	//////////////////////////////////////////////////////////////////////////	
	// This function will be called to adjust different values according to the game difficulty
	public static float AdjustValueAccordingToDifficulty(float valueToAdjust, float difference) {
		float val;
		
		// According to difficulty, adjust
		switch (settingGameDifficulty) {
		case GAME_DIFFICULTY_HARD:
			val = valueToAdjust - difference;
			break;
		case GAME_DIFFICULTY_NORMAL:
		default:
			val = valueToAdjust;
			break;
		case GAME_DIFFICULTY_EASY:
			val = valueToAdjust + difference;
			break;
		}
		
		return val;
	}

	//////////////////////////////////////////////////////////////////////////	
	// This function reset all settings
	public static void ResetSettings() {
		// Set tutorial mode
		PlayerPrefs.SetInt ("TUTORIAL MODE",1);
		// Set sound parameters
		PlayerPrefs.SetInt ("SETTING PLAY SOUND",1);
		PlayerPrefs.SetInt ("SETTING PLAY MUSIC",1);
		// Set Game Difficulty
		PlayerPrefs.SetInt ("SETTING GAME DIFFICULTY", 2); 
		// Currently Reached world
		PlayerPrefs.SetInt ("CURRENT LEVEL", 0); 

		// Set all stars
		for (int i = 0; i < LEVEL_NUMBER; i++) {
			PlayerPrefs.SetInt ("STARS FOR LEVEL " + i, 0);
		}

		// Save parameters
		PlayerPrefs.Save();
	}

}
