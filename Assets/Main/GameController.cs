using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	// Create a singleton of this object (SINGLETON DESIGN PATTERN)
	public static GameController uniqueController;

	// Internal variables
	public static int score;

	// Last time
	public static int minutes;
	public static int seconds;
	public static int fraction;

	// Definite times
	public static int iMinutes;
	public static int iSeconds;
	public static int iFraction;

	public static float startTime;

	private float timeT0;

	// Level Management
	public static int nGameMode;
	public static int currentLevel = AllGameParameters.START_LEVEL;

	// Are we in tutorial mode or not
	public bool bTutorialMode;

	//////////////////////////////////////////////////////////////////////////////////
	// Singleton
	//////////////////////////////////////////////////////////////////////////////////

	// Use this for early initialization
	void Awake () {
		if (uniqueController == null) {
			DontDestroyOnLoad(gameObject);
			uniqueController = this;
		} else if (uniqueController != this) {
			DestroyObject(gameObject);
		}		       
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Public Functions
	//////////////////////////////////////////////////////////////////////////////////

	public void RemoveTutorialMode() {
		bTutorialMode = false;
	}

	public void SetTutorialMode() {
		bTutorialMode = true;
	}

	public void InitializeT0() {
		timeT0 = Time.time;
	}

	public void InitializeStarTime() {
		startTime = SettingsParameters.AdjustValueAccordingToDifficulty(AllGameParameters.TIME_START_MEDIUM, AllGameParameters.TIME_START_DIFFERENCE);
	}

	public void resetScore() {
		score = 0;
	}

	public void increaseScore(int scoreToAdd) {
		score += scoreToAdd;
	}

	public int getScore() {
		return score;
	}

	public void setTimeValue() {
		iMinutes = minutes;
		iSeconds = seconds;
		iFraction = fraction;
	}

	public int GetSeconds() {
		return seconds;
	}

	public int GetMinutes() {
		return minutes;
	}

	public string getTimeValueInString() {
		return string.Format ("{0:0}:{1:00}:{2:00}", iMinutes, iSeconds, iFraction);
	}

	// Attribute bonus according to remaining time : 1 point for 1 millisecond
	public int giveScoreBonus() {
		return AllGameParameters.BONUS_FINISH_SCREEN + (iMinutes * 60 * 100 + iSeconds * 100 + iFraction);
	}

	public float getPassedTimeInSecondsWithDecimal() {
		int theRemainingTime = iMinutes * 60 + iSeconds;
		float ff = (startTime - theRemainingTime - (iFraction/100f));

		return ff;
	}
				
	// Manage the timer, if return NULL, then TIMEOUT
	public string timeMngt() {
		// Manage the time
		// Compute countdown
		float guiTime = (startTime + timeT0 /*+ extraTime*/) - Time.time;
		if (guiTime <= 0)
			return null;

		minutes = (int)(guiTime / 60);
		seconds = (int)(guiTime % 60);
		fraction = (int)((guiTime * 100) % 100);		

		return string.Format ("{0:0}:{1:00}:{2:00}", minutes, seconds, fraction);
	}

	public void flipSoundSetting() {
		if (SettingsParameters.settingPlaySound == true) 
			SettingsParameters.settingPlaySound = false;
		else
			SettingsParameters.settingPlaySound = true;
	}

	public void flipMusicSetting() {
		if (SettingsParameters.settingPlayMusic == true) {
			SettingsParameters.settingPlayMusic = false;
		} else {
			SettingsParameters.settingPlayMusic = true;
		}
	}

	public void flipTutorialSetting() {
		if (SettingsParameters.bTutorialMode == true) 
			SettingsParameters.bTutorialMode = false;
		else
			SettingsParameters.bTutorialMode = true;
	}

	public void flipDifficultySetting() {
		if (SettingsParameters.settingGameDifficulty == SettingsParameters.GAME_DIFFICULTY_EASY) {
			SettingsParameters.settingGameDifficulty = SettingsParameters.GAME_DIFFICULTY_NORMAL;
		} else if (SettingsParameters.settingGameDifficulty == SettingsParameters.GAME_DIFFICULTY_NORMAL) {
			SettingsParameters.settingGameDifficulty = SettingsParameters.GAME_DIFFICULTY_HARD;
		} else if (SettingsParameters.settingGameDifficulty == SettingsParameters.GAME_DIFFICULTY_HARD) {
			SettingsParameters.settingGameDifficulty = SettingsParameters.GAME_DIFFICULTY_EASY;
		}
	}

	public int getCurrenLevel() {
		return currentLevel;
	}

	public void setCurrenLevel(int lev) {
		currentLevel = lev;
	}

	public void incrementCurrenLevel() {
		currentLevel++;
	}

	public int getGameMode() {
		return nGameMode;
	}

	public void setGameMode(int mode) {
		nGameMode = mode;
	}
}
