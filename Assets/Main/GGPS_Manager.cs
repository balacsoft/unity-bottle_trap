using UnityEngine;
using System.Collections;

public class GGPS_Manager : MonoBehaviour {

	public static bool GGPS_AddScore(int gameMode, int scoreToAdd) {
#if UNITY_ANDROID
		long myScore = (long)scoreToAdd;
		string theLeaderBoard;
		bool result = false;

		// Set the corret leaderboard
		theLeaderBoard = BottleTrap_GGPS_Constants.leaderboard_campaign_highscores;
		if (gameMode == AllGameParameters.GAME_MODE_UNLIMITED) 
			theLeaderBoard = BottleTrap_GGPS_Constants.leaderboard_unlimited_high_scores;

		// Call Google Game Play Service and set the new score
		if (Social.localUser.authenticated) {
			Social.ReportScore (myScore, theLeaderBoard, (bool success) => {
				// handle success or failure
				if (success) {
					Debug.Log ("score added"+myScore);
					result = true;
					Social.ShowLeaderboardUI();
				} else {
					Debug.LogWarning ("Error adding Score");
				}
			});
		}
		return result;
#else
		return true;
#endif
	}

	public static bool GGPS_AddBestUnlimitedLevel(int gameMode, int levelToAdd) {
#if UNITY_ANDROID
		long myLevel = (long)levelToAdd;
		bool result = false;

		// Set the corret leaderboard
		if (gameMode != AllGameParameters.GAME_MODE_UNLIMITED)
			return false;

		// Call Google Game Play Service and set the new score
		if (Social.localUser.authenticated) {
			Social.ReportScore (myLevel, BottleTrap_GGPS_Constants.leaderboard_best_unlimited_level, (bool success) => {
				// handle success or failure
				if (success) {
					Debug.Log ("level added"+myLevel);
					result = true;
					Social.ShowLeaderboardUI();
				} else {
					Debug.LogWarning ("Error adding level");
				}
			});
		}
		return result;
#else
		return true;
#endif
	}

	public static bool GGPS_LocalGainAchievement(string theAchievement) {
		bool result = false;

#if UNITY_ANDROID
		if (Social.localUser.authenticated) {
			Social.ReportProgress (theAchievement, 100.0f, (bool success) => {
				if (success) {
					Debug.Log ("Achievement ADDED");
					result = true;
				} else {
					Debug.LogWarning ("Achievement ADDED ERROR");
				}
			});    
		}
#endif
			
		return result;
	}

	public static bool GGPS_GainAchievement(int gameMode, int currentLevel) {
		string theAchievement = "";
		bool result = false;

		// Checl level
		if (gameMode == AllGameParameters.GAME_MODE_UNLIMITED) {
			// UNLIMITED MODE
			switch (currentLevel) {
			case 1000:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_1000;
				break;
			case 500:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_500;
				break;
			case 200:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_200;
				break;
			case 100:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_100;
				break;
			case 50:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_50;
				break;
			case 20:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_20;
				break;
			case 10:
				theAchievement = BottleTrap_GGPS_Constants.achievement_unlimited_level_10;
				break;
			}
		} else {
			// CAMPAIGN MODE
			switch (currentLevel) {
			case 100:
				theAchievement = BottleTrap_GGPS_Constants.achievement_campaign_level_100;
				break;
			case 50:
				theAchievement = BottleTrap_GGPS_Constants.achievement_campaign_level_50;
				break;
			case 20:
				theAchievement = BottleTrap_GGPS_Constants.achievement_campaign_level_20;
				break;
			case 10:
				theAchievement = BottleTrap_GGPS_Constants.achievement_campaign_level_10;
				break;
			case 5:
				theAchievement = BottleTrap_GGPS_Constants.achievement_campaign_level_5;
				break;
			}
		}

		if (theAchievement != "") {
			result = GGPS_LocalGainAchievement (theAchievement);
		}

		return result;
	}

	public static bool GGPS_GainTimeAchievement(float thePassedTime) {
		string theAchievement = "";
		bool result = false;

		if (thePassedTime < 1f) {
			Debug.Log ("achievement_level_less_than_1s");
			theAchievement = BottleTrap_GGPS_Constants.achievement_level_less_than_1s;
		} else {
			if (thePassedTime < 2f) {
				Debug.Log ("achievement_level_less_than_2s");
				theAchievement = BottleTrap_GGPS_Constants.achievement_level_less_than_2s;
			} else {
				if (thePassedTime < 5f) {
					Debug.Log ("achievement_level_less_than_5s");
					theAchievement = BottleTrap_GGPS_Constants.achievement_level_less_than_5s;
				} else {
					if (thePassedTime < 10f) {
						Debug.Log ("achievement_level_less_than_10s");
						theAchievement = BottleTrap_GGPS_Constants.achievement_level_less_than_10s;
					}
				}
			}
		}

		if (theAchievement != "") {
			result = GGPS_LocalGainAchievement (theAchievement);
		}

		return result;
	}

}
