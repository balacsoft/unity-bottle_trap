using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	GameController myUniqueController;
	GameMusicController myMusicController;

	// Use this for initialization
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
	}

	// Use this for initialization
	void Start () {
		// Read preferences
		SettingsParameters.InitializeSettings();

		// Reset score and levels
		myUniqueController.resetScore ();
		myUniqueController.setCurrenLevel (0);

		// Start to play the TITLE music
		myMusicController.startTheMusic (GameMusicController.MUSIC_TITLE);
	}
	
}
