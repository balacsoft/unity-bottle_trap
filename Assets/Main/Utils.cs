using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class Utils {

	//////////////////////////////////////////////////////////////////////////////////
	// Public Functions
	//////////////////////////////////////////////////////////////////////////////////

	public static string RCNL = System.Environment.NewLine;

	// Retrieve a TextMesh object from the ObjectName
	public static Text GetTextWithName(string objName) {
		GameObject myTextObject;

		// Get Text Mesh Component
		myTextObject = GameObject.Find (objName);
		if (myTextObject == null)
			return null;
		return (Text)myTextObject.GetComponent<Text> ();
	}

	public static bool ConfirmationPopUp() {
		Transform myConfirmationButton;
		 
		myConfirmationButton = GameObject.FindGameObjectWithTag("ConfirmationButton").transform;
		if (myConfirmationButton == null)
			Debug.LogError ("CONFIRM BUTTON NULL");

		// Set button at middle of screen
		Vector3 vv = new Vector3 (0, 0, myConfirmationButton.position.z);
		myConfirmationButton.position = vv;

		return true;
	}

	public static bool ConfirmationPopUpRemove() {
		Transform myConfirmationButton;

		myConfirmationButton = GameObject.FindGameObjectWithTag("ConfirmationButton").transform;
		if (myConfirmationButton == null)
			Debug.LogError ("CONFIRM BUTTON NULL");

		// Set button out of screen
		Vector3 vv = new Vector3 (-1000, -1000, myConfirmationButton.position.z);
		myConfirmationButton.position = vv;

		return true;
	}

	public static bool TutorialPopUp() {
		Transform myTutorialButton;

		myTutorialButton = GameObject.FindGameObjectWithTag("TutorialQuestion").transform;
		if (myTutorialButton == null)
			Debug.LogError ("TutorialQuestion BUTTON NULL");

		// Set button at middle of screen
		Vector3 vv = new Vector3 (0, 0, myTutorialButton.position.z);
		myTutorialButton.position = vv;

		return true;
	}

	public static bool TutorialPopUpRemove() {
		Transform myConfirmationButton;

		myConfirmationButton = GameObject.FindGameObjectWithTag("TutorialQuestion").transform;
		if (myConfirmationButton == null)
			Debug.LogError ("TutorialQuestion BUTTON NULL");

		// Set button out of screen
		Vector3 vv = new Vector3 (-1000, -1000, myConfirmationButton.position.z);
		myConfirmationButton.position = vv;

		return true;
	}
}
