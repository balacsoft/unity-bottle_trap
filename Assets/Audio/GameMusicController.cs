using UnityEngine;
using System.Collections;

public class GameMusicController : MonoBehaviour {

	// Muziks
	public const int MUSIC_TITLE = 0;
	public const int MUSIC_GAME  = 1;

	// Audio source
	AudioSource myAudioSource;

	// Manage several musics
	AudioClip[] myClips;

	void Awake () {
		myClips = new AudioClip[] {
			(AudioClip)Resources.Load("Muziks/music_title"),
			(AudioClip)Resources.Load("Muziks/music_game")};		

		// Create AudioSource for music
		myAudioSource = gameObject.AddComponent<AudioSource>();
		if (myAudioSource == null) {
			Debug.LogWarning ("Error Creating Audiosource");
		}
		myAudioSource.loop = true;
		myAudioSource.clip = myClips[MUSIC_TITLE];
	}

	public void startTheMusic() {
		// If no music selected, start with title
		startTheMusic (MUSIC_TITLE);
	}

	public void startTheMusic(int theMusicToPlay) {
		if (SettingsParameters.settingPlayMusic == true) {
			// Music is activated in settings
			if ((myAudioSource.isPlaying == false) || (myAudioSource.clip != myClips [theMusicToPlay])) {
				// Debug.Log ("Start Music");
				myAudioSource.clip = myClips [theMusicToPlay];
				myAudioSource.Play ();
			} else {
				// Debug.Log ("Start Music - already playing");
			}
		}
	}
	public void stopTheMusic() {
		// Debug.Log("Stop Music");
		myAudioSource.Stop ();
	}
}
