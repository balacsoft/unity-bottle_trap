using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CampaignLevelSelectController : MonoBehaviour {

	int levelToDisplay;
	int nStarValue;
	Text myLevelToDisplayText;
	// Star Sprite
	public GameObject myStars;
	public GameObject myCadena;
	public SpriteRenderer sr;
	public Sprite spriteObject;
	GameController myUniqueController;

	// Use this for early initialization
	void Awake () {
		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError ("NULL myUniqueController!");
		}

		// Set application version
		myLevelToDisplayText = Utils.GetTextWithName ("CurrentLevel");    

		// Get Handle on Star object
		myStars = GameObject.FindGameObjectWithTag ("theStars");
		sr = (SpriteRenderer)myStars.GetComponent<SpriteRenderer>();

		// Get Handle on padlock (Cadena) object
		myCadena = GameObject.FindGameObjectWithTag ("Cadena");
	}

	// Use this for initialization
	void Start () {
		// Initialize data
		SettingsParameters.InitializeSettings();

		levelToDisplay = (SettingsParameters.currentlyReachedLevel+1);
		if (levelToDisplay > SettingsParameters.LEVEL_NUMBER)
			levelToDisplay = SettingsParameters.LEVEL_NUMBER;

		// by default, activate padlock (Cadenas)
		myCadena.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		// Update level message
		myLevelToDisplayText.text = "LEVEL " + levelToDisplay;

		// Display the stars
		nStarValue = SettingsParameters.starsForLevel[levelToDisplay-1];
		sr.sprite = (Sprite)Resources.Load("Stars/"+nStarValue+"-stars", typeof(Sprite));

		// Set padlock or not according to reached level
		if (levelToDisplay > (SettingsParameters.currentlyReachedLevel+1)) {
			// Display padlock, level not reached yet
			myCadena.SetActive (true);
		} else {
			myCadena.SetActive (false);
		}
	}

	public void CampaignLevelSelectionValidateGameButtonPressed() {
		if (levelToDisplay > (SettingsParameters.currentlyReachedLevel + 1)) {
			// Level unauthorized
			SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_ERROR);
		} else {
			// Level OK
			SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_COIN);
			myUniqueController.setCurrenLevel (levelToDisplay-1);
			SceneManager.LoadScene ("WaitScreen");
		}
	}

	public void CampaignLevelSelectionNextButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		if (levelToDisplay < SettingsParameters.LEVEL_NUMBER) {
			levelToDisplay++;
		} else {
			levelToDisplay = 1;
		}	
		// Debug.Log ("level="+levelToDisplay+"(reached="+SettingsParameters.currentlyReachedLevel+") Stars/" + nStarValue + "-stars"); // TO REMOVE
	}

	public void CampaignLevelSelectionPreviousButtonPressed() {
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		if (levelToDisplay > 1) {
			levelToDisplay--;
		} else {
			levelToDisplay = SettingsParameters.LEVEL_NUMBER;
		}	
		// Debug.Log ("level="+levelToDisplay+"(reached="+SettingsParameters.currentlyReachedLevel+") Stars/" + nStarValue + "-stars"); // TO REMOVE
	}
}
