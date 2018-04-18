using UnityEngine;
using System.Collections;

public class Fleche3Controller : MonoBehaviour {

	public void Locate(float x, float y) {
		Vector3 vect;
		vect = new Vector3 (x, y, -4f);
		transform.position = vect;
	}

	public void Hide() {
		Locate (-10f, -10f);
	}
}
