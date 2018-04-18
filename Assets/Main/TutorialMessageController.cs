using UnityEngine;
using System.Collections;

public class TutorialMessageController : MonoBehaviour {

	TextMesh tt;

	void Awake () {
		tt = (TextMesh)GetComponent<TextMesh>();
		if (tt == null)
			Debug.LogError ("ERROR TEXT MESH");
	}

	public void DisplayText(string txt) {
		tt.text = txt;
	}

	public void LocateText(float x, float y) {
		Vector3 vect;
		vect = new Vector3 (x, y, -4f);
		tt.transform.position = vect;
	}

	public void Hide() {
		tt.text = "";
	}
}
