using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EchiquierTutorialMngt : MonoBehaviour {

	// External references
	public GameController myUniqueController;
	public TutorialMessageController myTutoMsg;
	public Fleche1Controller myFleche1;
	public Fleche2Controller myFleche2;
	public Fleche3Controller myFleche3;

	private caseObject[ , ] theCases; 
	private carafeFinalObject theFinalCarafe;
	private carafeFinalObject theFinalCarafeTarget;

	// Graphic objects
	public GameObject petiteCarafe_1_4;
	public GameObject petiteCarafe_2_4;
	public GameObject petiteCarafe_3_4;
	public GameObject petiteCarafe_4_4;
	public GameObject petiteEmptyCarafe;
	public GameObject[,] allTheCarafes;
	public GameObject theFinalCarafeObj;
	public GameObject theFinalCarafeTargetObj;
	public GameObject petiteAcideCarafe;
	public GameObject petiteMurCarafe;

	// Managing carafe images
	public SpriteRenderer sr;
	public Sprite[] spriteObject;

	// Click positions
	private posInEchiquier_t clickPosDown;
	private posInEchiquier_t clickPosUp;

	// Score Management
	public Text scoreText;
	public Text levelText;
  	public TextMesh myTutorialMessage;
  
	// Time management
	public int levelTime = 0;
	public Text levelTimeText;

	// To manage bip on last 3 seconds
	bool bSecond3Done = false;
	bool bSecond2Done = false;
	bool bSecond1Done = false;

	// Mouse positions (X,Y) button down and up
	Vector2 posDown;
	Vector2 posUp;

	// State machine for tutorial mode
	int nStateMachine;
	bool bWaitingForMouse = false;

	caseObject[,,] theTutorialLevelCases = new caseObject[,,] {
 {		// LEVEL 1 
			{
				//                                     COLOR TYPE VOLUME POSITION GRAPHIC
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			}, {
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			}, {
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			}, {
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
 {		// LEVEL 2 
			{
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			}, {
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			}, {
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			}, {
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		}
	};

	carafeFinalObject[] theTutorialFinaleCarafeLevel = new carafeFinalObject[]
	{
		// COLOR VOLUME TYPE
		new carafeFinalObject(1, 2, 1),
		new carafeFinalObject(3, 3, 1)
	};

	//////////////////////////////////////////////////////////////////////////////////
	// Use this for initialization
	//////////////////////////////////////////////////////////////////////////////////

	// Early Initialization
	void Awake() {
		// Referenced objects
		myUniqueController = (GameController)GameObject.FindObjectOfType (typeof(GameController));
		if (myUniqueController == null) {
			Debug.LogError("NULL myUniqueController !");
		}
		myTutoMsg = (TutorialMessageController)GameObject.FindObjectOfType (typeof(TutorialMessageController));
		if (myTutoMsg == null) {
			Debug.LogError("NULL myTutorialMessageController !");
		}
		myFleche1 = (Fleche1Controller)GameObject.FindObjectOfType (typeof(Fleche1Controller));
		if (myFleche1 == null) {
			Debug.LogError("NULL myFleche1 !");
		}
		myFleche2 = (Fleche2Controller)GameObject.FindObjectOfType (typeof(Fleche2Controller));
		if (myFleche2 == null) {
			Debug.LogError("NULL myFleche2 !");
		}
		myFleche3 = (Fleche3Controller)GameObject.FindObjectOfType (typeof(Fleche3Controller));
		if (myFleche3 == null) {
			Debug.LogError("NULL myFleche3 !");
		}

		// Initialize Score
		scoreText = Utils.GetTextWithName ("ScoreValueText");
		levelTimeText = Utils.GetTextWithName ("TimeValueText");
		levelText = Utils.GetTextWithName ("LevelValueText");

		// Set mode to unlimited
		myUniqueController.setGameMode (AllGameParameters.GAME_MODE_CAMPAIGN);
		myUniqueController.setCurrenLevel (0);
	}

	// Initialization
	void Start () {
		GameObject myLocalCarafeObject;
		carafeObject theCarafe;
		Vector2 vect2;

		// Set the start time according to difficulty level
		myUniqueController.InitializeStarTime();

		// Load the images
		spriteObject = (Sprite[])Resources.LoadAll<Sprite>("carafe-map-final");

		// Create the carafeFinalTarget
		theFinalCarafeTarget = theTutorialFinaleCarafeLevel[myUniqueController.getCurrenLevel()];

		// Set the correct sprite for Final Carafe Target
		UpdateFinalCarafeTarget ();

		// Create all the cases
		theCases = new caseObject[AllGameParameters.ECHIQUIER_COLUMNS, AllGameParameters.ECHIQUIER_LINES]; 

		// Create all the Carafe objects (one per each case)
		allTheCarafes = new GameObject[AllGameParameters.ECHIQUIER_COLUMNS, AllGameParameters.ECHIQUIER_LINES];

		// If UNLIMITED mode, all is random
		for (int column=0;column<AllGameParameters.ECHIQUIER_COLUMNS;column++) {
			for (int line=0;line<AllGameParameters.ECHIQUIER_LINES;line++) {
				posInEchiquier_t pos;

				pos.x = column;
				pos.y = line;

				// Set objects according to level
				theCarafe = theTutorialLevelCases[myUniqueController.getCurrenLevel(), column , line].getCaseCarafe();
				if (theCarafe == null) 
					Debug.LogError("theCarafe="+theFinalCarafeTarget);

				theCases[column, line] = new caseObject(true, theCarafe);

				// Instantiate the Liquid objects (according to their volume)
				vect2 = getRealPos (column , line);
				myLocalCarafeObject = (GameObject)Instantiate (getCorrectObjWithVolume(theCarafe.getCarafeVolume() ,theCarafe.getCarafeType()), vect2, transform.rotation);
				if (myLocalCarafeObject == null)
					Debug.LogError ("ERROR myLocalCarafeObject");				 

				// Set the correct color to the object
				sr = (SpriteRenderer)myLocalCarafeObject.GetComponentsInChildren<SpriteRenderer>()[1];
				sr.color = getSpriteColor(theCarafe.getCarafeColor());

				// Set the carafes
				allTheCarafes[column, line] = myLocalCarafeObject;
			}
		}

		// Check if there is at least one red, one green and one blue, if not start again
		if (checkGameColors () == false) {
			//goto setEachCarafeInTheGame;
			SceneManager.LoadScene("Main");
		}

		// Set the FinaleCarafe Object (empty)
		theFinalCarafe = new carafeFinalObject (AllGameParameters.CARAFE_RED, AllGameParameters.VOLUME_1, AllGameParameters.LIQUID_TYPE_WATER);
		UpdateFinalCarafe();

		// Initialize positions outside the Echiquier
		clickPosDown = resetPosition ();
		clickPosUp = resetPosition ();

		// Set the start time
		myUniqueController.InitializeT0();

		// We start at first state machine
		nStateMachine = 0;
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Update is called once per frame
	//////////////////////////////////////////////////////////////////////////////////
	void Update () {
		carafeObject sourceCarafe;
		carafeObject destinationCarafe;
		string timeStr;

		// Check if waiting for a mouse button
		if (bWaitingForMouse == true) {
			if (Input.GetMouseButtonUp (0)) {
				HideMessage ();
				bWaitingForMouse = false;
				nStateMachine++;
			}
			return;
		}

		// Display the message according to the state
		TutorialStateMachine (nStateMachine);

		// Check objective of current state
		switch (nStateMachine) {
		case 1:
			// Red bottle at position 0, 2
			if ((theCases[0, 2].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_RED) && (theCases[0, 2].getCaseCarafe().getCarafeVolume() > AllGameParameters.VOLUME_0)){
				nStateMachine++;
				return;
			}
			break;
		case 4:
			// Red bottle at position 3,2
			if ((theCases[3, 2].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_RED) && (theCases[3, 2].getCaseCarafe().getCarafeVolume() > AllGameParameters.VOLUME_0)){
				nStateMachine++;
				return;
			}
			break;
		case 7:
			// green bottle at position 3,2
			if ((theCases[3, 2].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_GREEN) && (theCases[3, 2].getCaseCarafe().getCarafeVolume() > AllGameParameters.VOLUME_0)){
				nStateMachine++;
				return;
			}
			break;
		case 10:
			// Blue bottle at position 3,2
			if ((theCases[3, 2].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_BLUE) && (theCases[3, 2].getCaseCarafe().getCarafeVolume() > AllGameParameters.VOLUME_0)){
				nStateMachine++;
				return;
			}
			break;
		case 13:
			// Black bottle at position 3,2
			if ((theCases[3, 2].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_BLACK) && (theCases[3, 2].getCaseCarafe().getCarafeVolume() == AllGameParameters.VOLUME_1)){
				nStateMachine++;
				return;
			}
			break;
		case 16:
			// Green bottle at position 2,1
			if ((theCases[2, 1].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_GREEN) && (theCases[2, 1].getCaseCarafe().getCarafeVolume() == AllGameParameters.VOLUME_1_2)){
				nStateMachine++;
				return;
			}
			break;
		case 19:
			// Green bottle full at position 2,1
			if ((theCases[2, 1].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_GREEN) && (theCases[2, 1].getCaseCarafe().getCarafeVolume() == AllGameParameters.VOLUME_1)){
				nStateMachine++;
				return;
			}
			break;
		case 22:
			// red bottle 1/4 at position 2,1
			if ((theCases[2, 1].getCaseCarafe().getCarafeColor() == AllGameParameters.CARAFE_RED) && (theCases[2, 1].getCaseCarafe().getCarafeVolume() == AllGameParameters.VOLUME_1_4)){
				nStateMachine++;
				return;
			}
			break;
		}

		timeStr = myUniqueController.timeMngt ();
		if (timeStr == null) {
			// Set the start time
			myUniqueController.InitializeT0();
		} else {
			// Check if bip for last 3 seconds
			BipForLast3Seconds ();
		}

		// Update score text
		SetTextValue (timeStr);

		// MOUSE BUTTON DOWN
		if (Input.GetMouseButtonDown (0)) {
			// Get the position when the mouse button was DOWN
			posDown = getMouseClick();
			// And get echiquier position
			clickPosDown = getEchiquerClick(posDown);
			SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		}

		// MOUSE BUTTON UP
		if (Input.GetMouseButtonUp (0)) {
			// Get the position when the mouse button was UP
			posUp = getMouseClick();
			int n = GetCadran (posDown, posUp);
			clickPosUp = GetPositionFromCadran (clickPosDown, n);

			// We have to load new Recipient and unload current one
			if ((GetPositionBoundaries(clickPosUp) == false) || (GetPositionBoundaries(clickPosDown) == false)) {
				return;
			}

			sourceCarafe = theCases[clickPosDown.x,clickPosDown.y].getCaseCarafe();
			if (sourceCarafe.getCarafeVolume () == AllGameParameters.VOLUME_0)
				return;

			// Check if loading FinalCarafe
			if (checkFinalCarafeMovement()) {
				// Yes, we load FinaleCarafe
				SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_COIN);

				int remainingVolume;
				remainingVolume = theFinalCarafe.loadCarafe(sourceCarafe.getCarafeVolume(), sourceCarafe.getCarafeColor());
				sourceCarafe.unloadCarafe(remainingVolume);

				// Check if carafe is ACID type
				if (sourceCarafe.getCarafeType () == AllGameParameters.LIQUID_TYPE_ACID) {
					sourceCarafe.setCarafeVolume (AllGameParameters.VOLUME_0);
					sourceCarafe.setCarafeType (AllGameParameters.LIQUID_TYPE_WATER);
				}
				if (theFinalCarafe.getCarafeVolume () >= 0) {
					theFinalCarafe.setCarafeType (AllGameParameters.LIQUID_TYPE_WATER);
				} else {
					// If volume is negative, it is an ACID bottle
					theFinalCarafe.setCarafeType (AllGameParameters.LIQUID_TYPE_ACID);
				}

				// Update the display
				UpdateCarafeInPosition(sourceCarafe,clickPosDown.x,clickPosDown.y);
				UpdateFinalCarafe();

				// CHECK IF PLAYER HAS WIN !
				if ((theFinalCarafe.getCarafeColor() == theFinalCarafeTarget.getCarafeColor()) && (theFinalCarafe.getCarafeVolume() == theFinalCarafeTarget.getCarafeVolume())) {

					// LEVEL FINISHED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
					SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_FINISH);
					nStateMachine++;
				}

				return;
			}

			// Check if movement is possible (just around current position)
			if (checkMovement()) {
				// Determine the source & destination carafes
				sourceCarafe = theCases[clickPosDown.x,clickPosDown.y].getCaseCarafe();
				destinationCarafe = theCases[clickPosUp.x,clickPosUp.y].getCaseCarafe();

				// Check if source of destination is a WALL, in this case nothing happens
				if ((sourceCarafe.getCarafeType () == AllGameParameters.LIQUID_TYPE_WALL) || (destinationCarafe.getCarafeType () == AllGameParameters.LIQUID_TYPE_WALL))
					return;

				// movement is OK
				SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_COIN);

				// We have to load new Recipient and unload current one
				int remainingVolume;
				remainingVolume = destinationCarafe.loadCarafe(sourceCarafe.getCarafeVolume(), sourceCarafe.getCarafeColor());
				sourceCarafe.unloadCarafe(remainingVolume);

				// Check if carafe is ACID type
				if (sourceCarafe.getCarafeType () == AllGameParameters.LIQUID_TYPE_ACID) {
					sourceCarafe.setCarafeVolume (AllGameParameters.VOLUME_0);
					sourceCarafe.setCarafeType (AllGameParameters.LIQUID_TYPE_WATER);
				}
				if (destinationCarafe.getCarafeVolume () >= 0) {
					destinationCarafe.setCarafeType (AllGameParameters.LIQUID_TYPE_WATER);
				} else {
					// If volume is negative, it is an ACID bottle
					destinationCarafe.setCarafeType (AllGameParameters.LIQUID_TYPE_ACID);
				}

				// Update the display
				UpdateCarafeInPosition(sourceCarafe,clickPosDown.x,clickPosDown.y);
				UpdateCarafeInPosition(destinationCarafe,clickPosUp.x,clickPosUp.y);

				myUniqueController.increaseScore(1);
			} else {
				// Debug.LogWarning ("MOV KO"); // TO REMOVE
				clickPosDown = resetPosition ();
				clickPosUp = resetPosition ();
			}
		}
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Public functiuns
	//////////////////////////////////////////////////////////////////////////////////

	// Is called when 'MENU' button is pressed during game
	public void GameMainMenuButtonPressed() {
		// Play a sound
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_CLICK);
		// Start the time
		Time.timeScale = 1f;
		SceneManager.LoadScene ("StartMenu");
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Local functiuns
	//////////////////////////////////////////////////////////////////////////////////

	// Message to display according to the state
	void TutorialStateMachine(int nState) {
		// At the beginning the time is stopped
		Time.timeScale = 0f;
		scoreText.text = "TUTORIAL";
		bWaitingForMouse = false;
		carafeObject theCarafe;
		posInEchiquier_t pos;

		switch (nState) {
		case 0:
			levelText.text = "STEP 1/9 " + Utils.RCNL + " MOVEMENTS";
			myTutoMsg.LocateText (-1.6f, 3.0f);
			myTutoMsg.DisplayText ("First learn movements:" + Utils.RCNL + " move red bottle from (1) " + Utils.RCNL + "to (2) using drag'n drop");
			myFleche1.Locate (-4.2f, 2.4f);
			myFleche2.Locate (-4.1f, -2.0f);
			myFleche3.Hide ();
			WaitAMouseButton ();
			break;

		case 1:
			ReStartGame ();
			break;

		case 2:
			WellDone ();
			break;

		case 3:
			levelText.text = "STEP 2/9" + Utils.RCNL + "WALLS";
			pos.x = 2;
			pos.y = 2;

			theCarafe = new carafeObject (1, AllGameParameters.LIQUID_TYPE_WALL, 1, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [2, 2] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, 2, 2);

			myTutoMsg.LocateText (-1.6f, 3.3f);
			myTutoMsg.DisplayText ("It is not possible" + Utils.RCNL + " to cross a wall" + Utils.RCNL + "Try moving to position (2)");
			myFleche1.Locate (-0.3f, -1.8f);
			myFleche2.Locate (2.2f, -2.1f);
			WaitAMouseButton ();
			break;

		case 4:
			ReStartGame ();
			break;

		case 5:
			WellDone ();
			break;

		case 6:
			levelText.text = "STEP 3/9" + Utils.RCNL + "COLOR MIXING";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a blue bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLUE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a red bottle at 3,2
			pos.x = 3;
			pos.y = 2;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_RED, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_2, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set messages and arrows
			myTutoMsg.LocateText (-1.6f, 3.5f);
			myTutoMsg.DisplayText ("Move bottle (1) to (2)" + Utils.RCNL + "will create a new color" + Utils.RCNL + "blue+red=green" + Utils.RCNL + "red+green=blue" + Utils.RCNL + "blue+green=red");
			myFleche1.Locate (-4.1f, 2.24f);
			myFleche2.Locate (2.2f, -1.96f);
			WaitAMouseButton ();
			break;

		case 7:
			ReStartGame ();
			break;

		case 8:
			WellDone ();
			break;

		case 9:
			levelText.text = "STEP 4/9" + Utils.RCNL + "WHITE COLOR";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a blue bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLUE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a red bottle at 3,2
			pos.x = 3;
			pos.y = 2;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_WHITE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_3_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set messages and arrows
			myTutoMsg.LocateText (-1.6f, 3.5f);
			myTutoMsg.DisplayText ("Move bottle (1) to (2)" + Utils.RCNL + "White does not change color" + Utils.RCNL + "blue+white=blue" + Utils.RCNL + "red+white=red" + Utils.RCNL + "green+white=green");
			myFleche1.Locate (-4.1f, 2.24f);
			myFleche2.Locate (2.2f, -1.96f);
			WaitAMouseButton ();
			break;

		case 10:
			ReStartGame ();
			break;

		case 11:
			WellDone ();
			break;

		case 12:
			levelText.text = "STEP 5/9" + Utils.RCNL + "BLACK COLOR";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a blue bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLUE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a black bottle at 3,2
			pos.x = 3;
			pos.y = 2;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLACK, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_3_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set messages and arrows
			myTutoMsg.LocateText (-1.6f, 3.5f);
			myTutoMsg.DisplayText ("Move bottle (1) to (2)" + Utils.RCNL + "Black always remains black" + Utils.RCNL + "blue+black=black" + Utils.RCNL + "red+black=black" + Utils.RCNL + "green+black=black");
			myFleche1.Locate (-4.1f, 2.24f);
			myFleche2.Locate (2.2f, -1.96f);
			WaitAMouseButton ();
			break;

		case 13:
			ReStartGame ();
			break;

		case 14:
			WellDone ();
			break;

		case 15:
			levelText.text = "STEP 6/9" + Utils.RCNL + "VOLUME 1/2";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a red bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_RED, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a blue bottle at 2,1
			pos.x = 2;
			pos.y = 1;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLUE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set messages and arrows
			myTutoMsg.LocateText (-6.4f, -1.34f);
			myTutoMsg.DisplayText ("Move bottle (1) to (2)" + Utils.RCNL + "volumes are added:" + Utils.RCNL + "quarter bottle + quarter = half bottle" + Utils.RCNL + "1/4 + 1/2 = 3/4" + Utils.RCNL + "1/2 + 1/2 = 1, etc.");
			myFleche1.Locate (-4.1f, 2.24f);
			myFleche2.Locate (0.2f, 0.13f);
			WaitAMouseButton ();
			break;

		case 16:
			ReStartGame ();
			break;

		case 17:
			WellDone ();
			break;

		case 18:
			levelText.text = "STEP 7/9" + Utils.RCNL + "VOLUME 2/2";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a red bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_RED, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_2, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a blue bottle at 2,1
			pos.x = 2;
			pos.y = 1;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLUE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_3_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set messages and arrows
			myTutoMsg.LocateText (-6.4f, -1.34f);
			myTutoMsg.DisplayText ("Volumes are added" + Utils.RCNL + "but if destination bottle is full" + Utils.RCNL + "liquid may remain in source bottle" + Utils.RCNL + "1/2 + 3/4 = Full, remains 1/4");
			myFleche1.Locate (-4.1f, 2.24f);
			myFleche2.Locate (0.2f, 0.13f);
			WaitAMouseButton ();
			break;

		case 19:
			ReStartGame ();
			break;

		case 20:
			WellDone ();
			break;

		case 21:
			levelText.text = "STEP 8/9" + Utils.RCNL + "ACID LIQUID";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a red bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_RED, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_2, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a blue bottle at 2,1
			pos.x = 2;
			pos.y = 1;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_WHITE, AllGameParameters.LIQUID_TYPE_ACID, AllGameParameters.VOLUME_NEGATIF, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set messages and arrows
			myTutoMsg.LocateText (-6.4f, -1.34f);
			myTutoMsg.DisplayText ("Acid dissolves 1/4 of liquid" + Utils.RCNL + "Here: half red + acid = quarter red");
			myFleche1.Locate (-4.1f, 2.24f);
			myFleche2.Locate (0.2f, 0.13f);
			WaitAMouseButton ();
			break;

		case 22:
			ReStartGame ();
			break;

		case 23:
			WellDone ();
			break;

		case 24:
			levelText.text = "STEP 9/9" + Utils.RCNL + "GAME OBJECTIVE";

			// All bottles are removed (empty bottles)
			RemoveAllBottles ();

			// Set a red bottle at 0,0
			pos.x = 0;
			pos.y = 0;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_RED, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_4, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Set a blue bottle at 2,2
			pos.x = 2;
			pos.y = 2;
			theCarafe = new carafeObject (AllGameParameters.CARAFE_BLUE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_1_2, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
			theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
			// Set the carafes
			UpdateCarafeInPosition (theCarafe, pos.x, pos.y);

			// Final target bottle = 3/4 green
			// Create the carafeFinalTarget
			theFinalCarafeTarget = theTutorialFinaleCarafeLevel[1];
			// Set the correct sprite for Final Carafe Target
			UpdateFinalCarafeTarget ();

			// Set the FinaleCarafe Object (empty)
			theFinalCarafe = new carafeFinalObject (AllGameParameters.CARAFE_WHITE, AllGameParameters.VOLUME_0, AllGameParameters.LIQUID_TYPE_WATER);
			UpdateFinalCarafe();

			// Set messages and arrows
			myTutoMsg.LocateText (-2.54f, 2.7f);
			myTutoMsg.DisplayText ("Game objective is to obtain" + Utils.RCNL + "same liquid in final bottle (1)" + Utils.RCNL + "and target bottle (2)" + Utils.RCNL + "by dragging from last square (3)"+Utils.RCNL+"Here: 3/4 green");
			myFleche1.Locate (5.1f, -4.4f);
			myFleche2.Locate (5.26f, -1.99f);
			myFleche3.Locate (1.97f, -4.17f);
			WaitAMouseButton ();
			break;

		case 25:
			ReStartGame ();
			break;

		case 26:
			myTutoMsg.LocateText (-4.5f, 1f);
			myTutoMsg.DisplayText ("Well done !" + Utils.RCNL + "You have finished the TUTORIAL !"+ Utils.RCNL + "Now, it is time to play");
			WaitAMouseButton ();
			break;

		case 27:
			// and we reset the flag so tutorial mode is never asked again
			SettingsParameters.bTutorialMode = false;
			SettingsParameters.SaveSettings ();

			// Make the time normal before
			Time.timeScale = 1f;

			// Load main scene
			SceneManager.LoadScene ("StartMenu");
			break;

		default:
			ReStartGame ();
			break;
		}
	}

	void WaitAMouseButton() {
		bWaitingForMouse = true;
	}

	void HideMessage() {
		myTutoMsg.Hide ();
	}

	void ReStartGame() {
		Time.timeScale = 1f;
	}

	void RemoveAllBottles() {
		carafeObject theCarafe;
		posInEchiquier_t pos;

		for (pos.x = 0; pos.x < AllGameParameters.ECHIQUIER_COLUMNS; pos.x++) {
			for (pos.y = 0; pos.y < AllGameParameters.ECHIQUIER_LINES; pos.y++) {
				theCarafe = new carafeObject (AllGameParameters.CARAFE_WHITE, AllGameParameters.LIQUID_TYPE_WATER, AllGameParameters.VOLUME_0, pos, AllGameParameters.GRAPHICAL_TYPE_STANDARD);
				theCases [pos.x, pos.y] = new caseObject (true, theCarafe);
				// Set the carafes
				UpdateCarafeInPosition (theCarafe, pos.x, pos.y);
			}
		}
	}

	void WellDone() {
		myTutoMsg.LocateText (-1.6f, 2.5f);
		myTutoMsg.DisplayText ("Well done !");
		SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_GREAT);
		WaitAMouseButton ();
	}

	// Determine destination position according to previous position and cadran where mouse released (MOUSE UP)
	private posInEchiquier_t GetPositionFromCadran(posInEchiquier_t previousPosition, int cadran) {
		int deltaX, deltaY;
		posInEchiquier_t result = previousPosition;

		// Compute increments/decrements according to cadran
		switch (cadran) {
		case 1:
			deltaX = 1;
			deltaY = 0;
			break;
		case 2:
			deltaX = 1;
			deltaY = -1;
			break;
		case 3:
			deltaX = 0;
			deltaY = -1;
			break;
		case 4:
			deltaX = -1;
			deltaY = -1;
			break;
		case 5:
			deltaX = -1;
			deltaY = 0;
			break;
		case 6:
			deltaX = -1;
			deltaY = 1;
			break;
		case 7:
			deltaX = 0;
			deltaY = 1;
			break;
		case 8:
			deltaX = 1;
			deltaY = 1;
			break;
		default:
			deltaX = 0;
			deltaY = 0;
			break;
		}

		result.x += deltaX;
		result.y += deltaY;

		return result;
	}

	// Get cadran from mouse positions (DOWN=a and UP=b)
	private int GetCadran(Vector2 a, Vector2 b) {
		int nCadran = -1;

		// Compute cadran : angle = arctan ((y2-y1)/(x2 - x1))
		float hh = Mathf.Atan2(b.y - a.y, b.x - a.x);
		float ff = hh * Mathf.Rad2Deg;

		// Determine cadran according to angle
		if ((ff > -22.5f) && (ff <= 22.5f)) 
			nCadran = 1;
		if ((ff > 22.5f) && (ff <= 67.5f)) 
			nCadran = 2;
		if ((ff > 67.5f) && (ff <= 112.5f)) 
			nCadran = 3;
		if ((ff > 112.5f) && (ff <= 157.5f)) 
			nCadran = 4;
		if ((ff > 157.5f) || (ff <= -157.5f)) 
			nCadran = 5;
		if ((ff > -157.5f) && (ff <= -112.5f)) 
			nCadran = 6;
		if ((ff > -112.5f) && (ff <= -67.5f)) 
			nCadran = 7;
		if ((ff > -67.5f) && (ff <= -22.5f)) 
			nCadran = 8;

		return nCadran;
	}

	// Check if coordinates are in the echiquier=true, outside=false
	private bool GetPositionBoundaries(posInEchiquier_t inPos) {

		// Target case
		if ((inPos.x == AllGameParameters.ECHIQUIER_COLUMNS) && (inPos.y == (AllGameParameters.ECHIQUIER_LINES-1)))
			return true;

		// check if case is outside
		if ((inPos.x < 0) || (inPos.x >= AllGameParameters.ECHIQUIER_COLUMNS)) {
			return false;
		} else {
			if ((inPos.y < 0) || (inPos.y >= AllGameParameters.ECHIQUIER_LINES))
				return false;
			else
				return true;
		}
	}

	// Check if there is at least one red, one green and one blue in the game
	private bool checkGameColors() {
		bool bResult = false;
		bool bRed = false;
		bool bBlue = false;
		bool bGreen = false;

		// No problem in Campaign mode
		if (myUniqueController.getGameMode () == AllGameParameters.GAME_MODE_CAMPAIGN)
			return true;

		for (int column=0;column<AllGameParameters.ECHIQUIER_COLUMNS;column++) {
			for (int line=0;line<AllGameParameters.ECHIQUIER_LINES;line++) {

				// Get the color of the case
				int maColor = theCases [column, line].getCaseCarafe ().getCarafeColor ();

				// If case is empty (=0) or negative, do not take it, or if case is not a liquid
				if ((theCases [column, line].getCaseCarafe ().getCarafeVolume () < 1) || (theCases [column, line].getCaseCarafe ().getCarafeType() != AllGameParameters.LIQUID_TYPE_WATER))
					maColor = -1;

				if (maColor == AllGameParameters.CARAFE_BLUE) {
					bBlue = true;
				} else if (maColor == AllGameParameters.CARAFE_RED) {
					bRed = true;
				} else if (maColor == AllGameParameters.CARAFE_GREEN) {
					bGreen = true;
				}
			}
		}		

		if ((bRed == true) && (bBlue == true) && (bGreen == true))
			bResult = true;

		return bResult;
	}

	// Update the final Carafe (update volume and color)
	private void UpdateFinalCarafe() {
		Vector2 vect2;
		vect2 = theFinalCarafeObj.transform.position;
		DestroyObject (theFinalCarafeObj);

		theFinalCarafeObj = (GameObject)Instantiate (getCorrectObjWithVolume(theFinalCarafe.getCarafeVolume(), theFinalCarafe.getCarafeType()), vect2, transform.rotation);
		theFinalCarafeObj.transform.localScale = new Vector3 (-0.4f, 0.4f, 0.4f);

		sr = (SpriteRenderer)theFinalCarafeObj.GetComponentsInChildren<SpriteRenderer> () [1];
		sr.color = getSpriteColor (theFinalCarafe.getCarafeColor ());
	}

	// Update the final Target Carafe (update volume and color)
	private void UpdateFinalCarafeTarget() {
		Vector2 vect2;
		vect2 = theFinalCarafeTargetObj.transform.position;
		DestroyObject (theFinalCarafeTargetObj);

		theFinalCarafeTargetObj = (GameObject)Instantiate (getCorrectObjWithVolume(theFinalCarafeTarget.getCarafeVolume(), theFinalCarafeTarget.getCarafeType()), vect2, transform.rotation);
		theFinalCarafeTargetObj.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
		sr = (SpriteRenderer)theFinalCarafeTargetObj.GetComponentsInChildren<SpriteRenderer> () [1];
		sr.color = getSpriteColor (theFinalCarafeTarget.getCarafeColor ());
	}

	// Update a Carafe at the defined position (update volume and color)
	private void UpdateCarafeInPosition(carafeObject carafeToUpdate, int xx, int yy) {
		GameObject go;
		GameObject currentCarafe;

		currentCarafe = allTheCarafes[xx,yy];
		go = (GameObject)Instantiate (getCorrectObjWithVolume(carafeToUpdate.getCarafeVolume(), carafeToUpdate.getCarafeType()), currentCarafe.transform.position, transform.rotation);
		DestroyObject(currentCarafe);
		allTheCarafes[xx,yy] = go;

		// Set the correct color to the object
		sr = (SpriteRenderer)go.GetComponentsInChildren<SpriteRenderer>()[1];
		sr.color = getSpriteColor(carafeToUpdate.getCarafeColor());
	}

	// Get the correct LIQUID Object with the volume value and the type
	private Object getCorrectObjWithVolume(int vol, int carafeType) {
		Object myObject = petiteEmptyCarafe;

		if (carafeType == AllGameParameters.LIQUID_TYPE_ACID) {
			myObject = petiteAcideCarafe;
		} else if (carafeType == AllGameParameters.LIQUID_TYPE_WALL) { 
			myObject = petiteMurCarafe;
		} else {
			switch (vol) {
			case AllGameParameters.VOLUME_0:
			default:
				myObject = petiteEmptyCarafe;
				break;
			case AllGameParameters.VOLUME_1_2:
				myObject = petiteCarafe_2_4;
				break;
			case AllGameParameters.VOLUME_3_4:
				myObject = petiteCarafe_3_4;
				break;
			case AllGameParameters.VOLUME_1_4:
				myObject = petiteCarafe_1_4;
				break;
			case AllGameParameters.VOLUME_1:
				myObject = petiteCarafe_4_4;
				break;
			}
		}

		return myObject;
	}

	// Set position volontarely outside the Echiquier
	private posInEchiquier_t resetPosition () {
		posInEchiquier_t pos;

		pos.x = 9;
		pos.y = 9;

		return pos;
	}

	// Check if the movement is to load finalCarafe => source=7,7 and destination is >7, 7
	private bool checkFinalCarafeMovement() {
		if ((clickPosDown.x == (AllGameParameters.ECHIQUIER_COLUMNS-1)) && (clickPosDown.y == (AllGameParameters.ECHIQUIER_LINES-1)) 
			&& (clickPosUp.x > (AllGameParameters.ECHIQUIER_COLUMNS-1)) && ((clickPosUp.y == (AllGameParameters.ECHIQUIER_LINES-1)) 
				|| (clickPosUp.y == AllGameParameters.ECHIQUIER_LINES)))
			return true;
		else
			return false;
	}

	// Check if the movement is allowed (between UP and DOWN mouse click button)
	private bool checkMovement() {
		// Check if clicks are in Echiquier
		if ((clickPosDown.x < 0) || (clickPosDown.x > 7) || (clickPosDown.y < 0) || (clickPosDown.y > 7))
			return false;
		if ((clickPosUp.x < 0) || (clickPosUp.x > 7) || (clickPosUp.y < 0) || (clickPosUp.y > 7))
			return false;

		// Check if only 1 case between click down and click UP
		if (Mathf.Abs (clickPosUp.x - clickPosDown.x) > 1)
			return false;
		if (Mathf.Abs (clickPosUp.y - clickPosDown.y) > 1)
			return false;

		// If destination and source are equal, quit
		if ((clickPosUp.x == clickPosDown.x) && (clickPosUp.y == clickPosDown.y)) 
			return false;

		return true;
	}

	// Provide position according to where the mouse is
	private Vector2 getMouseClick() {
		// Determine click position
		Vector2 pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint (pos);
		return pos;
	}

	// Provide Echiquier position according to where the mouse is
	private posInEchiquier_t getEchiquerClick(Vector2 thePos) {
		// Determine click position
		return getEchiquierPos (thePos);
	}

	// Compute coordinates in real world from coordinates in Echiquier world
	private Vector2 getRealPos(int posX, int posY) {
		Vector2 vect;

		vect.x = ((posX * AllGameParameters.GAP_BETWEEN_CELLS_X) + AllGameParameters.POSITION_CELL_TOP_LEFT_X);
		vect.y = (AllGameParameters.POSITION_CELL_TOP_LEFT_Y - (posY * AllGameParameters.GAP_BETWEEN_CELLS_Y));

		return vect;
	}

	// Compute coordinates in real world from coordinates in Echiquier world
	private posInEchiquier_t getEchiquierPos(Vector3 vect3) {
		posInEchiquier_t posEchiq;
		Vector2 vect;

		vect.x = ((vect3.x  + 4.08f) /  AllGameParameters.GAP_BETWEEN_CELLS_X);
		vect.y = ((4.14f - vect3.y) / AllGameParameters.GAP_BETWEEN_CELLS_Y);

		posEchiq.x = (int)vect.x;
		posEchiq.y = (int)vect.y;

		return posEchiq;
	}

	// Set color
	private Color getSpriteColor(int color) {
		Color col;

		// Colors are in order: white, blue, black, red, green, empty
		switch (color) {
		case AllGameParameters.CARAFE_WHITE:
			col = new Color (255,255,255,AllGameParameters.WHITE_TRANSPARENCE);
			break;
		case AllGameParameters.CARAFE_BLUE:
			col = new Color (0,0,255,AllGameParameters.COLOR_TRANSPARENCE);
			break;
		case AllGameParameters.CARAFE_BLACK:
			col = new Color (0,0,0,AllGameParameters.COLOR_TRANSPARENCE);
			break;
		case AllGameParameters.CARAFE_RED:
			col = new Color (255,0,0,AllGameParameters.COLOR_TRANSPARENCE);
			break;
		case AllGameParameters.CARAFE_GREEN:
			col = new Color (0,255,0,AllGameParameters.COLOR_TRANSPARENCE);
			break;
		default:
			col = new Color (0,0,0,AllGameParameters.COLOR_TRANSPARENCE);
			Debug.LogError("ERROR COLOR");
			break;
		}

		return col;
	}

	// Give the sprite index in SPRITE MAP according to the volume
	private int getSpriteIndexInResource(int volume) {
		int val = 0;

		// Offset with volume
		if (volume == AllGameParameters.VOLUME_0) {
			val = 20;
		} else if (volume == AllGameParameters.VOLUME_1_2) {
			val = 0;
		} else if (volume == AllGameParameters.VOLUME_1_4) {
			val = 7;
		} else if (volume == AllGameParameters.VOLUME_3_4) {
			val = 14;
		} else if (volume == AllGameParameters.VOLUME_1) {
			val = 21;
		}

		return val;
	}

	// Get a random Type
	int getRandomType() {
		float fVal;
		int val, theType;

		fVal = Random.value;
		fVal = (10 * fVal);
		val = (int)fVal;

		switch (val) {
		default:
			theType = AllGameParameters.LIQUID_TYPE_WATER;
			break;
		case 8:
			theType = AllGameParameters.LIQUID_TYPE_ACID;
			break;
		case 9:
			theType = AllGameParameters.LIQUID_TYPE_WALL;
			break;
		}

		return theType;
	}

	// Get a random color
	int getRandomColor() {
		float fVal;
		int val;

		fVal = Random.value;
		fVal = (10 * fVal);
		val = (int)fVal;
		val = (int)(val/2) + 1;

		return val;
	}

	// Get a random color only in Red, Green, Blue
	int getRandomColorRGB() {
		float fVal;
		int val;

		do {
			fVal = Random.value;
			fVal = (10 * fVal);
			val = (int)fVal;
			val = (int)(val/3) + 1;
		} while((val<1) || (val>3));

		return val;
	}

	// Get random volume
	int getRandomVolume() {
		float fVal;
		int val;

		fVal = Random.value;
		fVal = (10 * fVal);
		val = (int)fVal;
		val = (int)(val/2);

		return val;
	}

	// Update the text display
	void SetTextValue(string timeText) {
		levelTimeText.text = timeText;
	}

	//////////////////////////////////////////////////////////////////////////////////////
	/**
	* \brief Manage bips of the last 3 seconds of the countdown
	*
	* \param void 
	* \return void
		*/
		void BipForLast3Seconds() {
		int seconds = myUniqueController.GetSeconds ();
		int minutes = myUniqueController.GetMinutes ();

		if (minutes > 0) {
			return;
		}

		// Add a bit when seconds are 3, 2 or 1
		if ((seconds < 3) && (bSecond3Done == false)) {
			myTutoMsg.LocateText (-2f, 2f);
			myTutoMsg.DisplayText ("Be careful time !" + Utils.RCNL + "No problem in tutorial mode");
			SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_BEEP);
			bSecond3Done = true;
		}
		if ((seconds < 2) && (bSecond2Done == false)) {
			SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_BEEP);
			bSecond2Done = true;
		}
		if ((seconds < 1) && (bSecond1Done == false)) {
			myTutoMsg.DisplayText ("");
			SoundManager.gameSoundManager.PlaySound(SoundManager.SOUND_BEEP);
			bSecond1Done = true;
		}
	}

}
