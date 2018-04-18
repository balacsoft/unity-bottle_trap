using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarsController : MonoBehaviour {

	GameController myUniqueController;
 	// Sprite
	public GameObject myStars;
	public SpriteRenderer sr;
	public Sprite spriteObject;

	// Number of stars
	int curLevelStars = 0;

	void Awake () {
		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError ("NULL myUniqueController!");
		}

		// Get handle on Star object
		myStars = GameObject.FindGameObjectWithTag ("theStars");
		sr = (SpriteRenderer)myStars.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		// Set the stars according to the time
		SetStarValues();

		// Save number of stars for this level in Campaign mode
		if (myUniqueController.getGameMode() == AllGameParameters.GAME_MODE_CAMPAIGN) {
			int curLevel = myUniqueController.getCurrenLevel ();

			if (curLevel > 0)  {
				if (curLevelStars > SettingsParameters.starsForLevel [curLevel - 1]) {
					// Save stars for this level
					SettingsParameters.starsForLevel [curLevel - 1] = curLevelStars;
					// Save parameters in persistant data
					SettingsParameters.SaveSettings ();
				}
			}			
		}
	}

	// Update the stars (0, 1, 2 or 3)
	void SetStarValues() {
		curLevelStars = 0;

		// Check elapsed time in current level
		float passedTimeInSeconds = myUniqueController.getPassedTimeInSecondsWithDecimal ();

		if (passedTimeInSeconds > 0) {
			if (passedTimeInSeconds < AllGameParameters.TIME_3STARS) {
				curLevelStars = 3;
			} else if (passedTimeInSeconds < AllGameParameters.TIME_2STARS) {
				curLevelStars = 2;
			} else if (passedTimeInSeconds < AllGameParameters.TIME_1STARS) {
				curLevelStars = 1;
			}
		}
//		Debug.Log ("level=" + myUniqueController.getCurrenLevel () + "-Stars=" + theStarValue + "-currentStars="+SettingsParameters.starsForLevel[myUniqueController.getCurrenLevel ()]);

		// Display the stars
		sr.sprite = (Sprite)Resources.Load("Stars/"+curLevelStars+"-stars", typeof(Sprite));
	}
}
