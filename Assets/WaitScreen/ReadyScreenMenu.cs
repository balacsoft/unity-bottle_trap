using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReadyScreenMenu : MonoBehaviour {

	GameController myUniqueController;
	GameMusicController myMusicController;

	// Score Management
	public Text scoreText;
	public Text timeText;
	public Text levelText;

	void Awake () {
		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError ("NULL myUniqueController!");
		}

		// Start the music
		myMusicController = (GameMusicController)GameObject.FindObjectOfType (typeof(GameMusicController));
		if (myMusicController == null) {
			Debug.LogError ("NULL myMusicController!");
		}

		// Initialize
		scoreText = Utils.GetTextWithName ("ScoreValueText");
		timeText = Utils.GetTextWithName ("TimeValueText");
		levelText = Utils.GetTextWithName ("LevelValueText");
	}

	// Use this for initialization
	void Start () {
		// Read preferences
		SettingsParameters.InitializeSettings();

		// Start to play the TITLE music
		myMusicController.startTheMusic (GameMusicController.MUSIC_GAME);

		// Set the score
		SetTextValue();
	}

	// Update the text display
	void SetTextValue() {
		string text;

		text = myUniqueController.getScore().ToString ("0000000");
		scoreText.text = text;

		timeText.text = myUniqueController.getTimeValueInString ();
		levelText.text = (myUniqueController.getCurrenLevel ()+1).ToString("000");
	}
		
}
