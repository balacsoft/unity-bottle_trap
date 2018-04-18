using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////////////////
///  All game constants 
//////////////////////////////////////////////////////////////////////////////////
/// 
public static class AllGameParameters {

	/*
	// Echiquier size
	public const int ECHIQUIER_COLUMNS 			= 8;
	public const int ECHIQUIER_LINES 			= 8;
	
	// Gap between 2 cells
	public const float GAP_BETWEEN_CELLS_X 		= 1.035f;
	public const float GAP_BETWEEN_CELLS_Y 		= 1.035f;
	
	// Position of cells
	public const float POSITION_CELL_TOP_LEFT_X = -3.573f;
	public const float POSITION_CELL_TOP_LEFT_Y = 3.625f;
	*/

	// Echiquier size
	public const int ECHIQUIER_COLUMNS 			= 4;
	public const int ECHIQUIER_LINES 			= 4;

	// Gap between 2 cells
	public const float GAP_BETWEEN_CELLS_X		= 2*1.035f;
	public const float GAP_BETWEEN_CELLS_Y 		= 2*1.035f;

	// Position of cells
	public const float POSITION_CELL_TOP_LEFT_X = -3.0f;
	public const float POSITION_CELL_TOP_LEFT_Y = 3.1f;

	// error codes
	public const int ERRO_CODE_OK 				= 0;

	// Carafe colors
	public const int CARAFE_RED 				= 1;
	public const int CARAFE_BLUE 				= 2;
	public const int CARAFE_GREEN 				= 3;
	public const int CARAFE_WHITE 				= 4;
	public const int CARAFE_BLACK 				= 5;
	public const float COLOR_TRANSPARENCE 		= 0.5f; // Level of transparency
	public const float WHITE_TRANSPARENCE 		= 0.9f; // Level of transparency

	// Carafe volumes
	public const int VOLUME_NEGATIF				= -1;
	public const int VOLUME_0					= 0;
	public const int VOLUME_1_4					= 1;
	public const int VOLUME_1_2					= 2;
	public const int VOLUME_3_4					= 3;
	public const int VOLUME_1					= 4;

	// Type Graphical
	public const int GRAPHICAL_TYPE_STANDARD 	= 0;

	// Type of liquid
	public const int LIQUID_TYPE_WATER 			= 1;
	public const int LIQUID_TYPE_ACID 			= 2;
	public const int LIQUID_TYPE_WALL 			= 3;
	public const int LIQUID_TYPE_CHANGING 		= 4;

	// Score values
	public const int BONUS_FINISH_SCREEN 		= 100;

	// Time at start of level
	public const float TIME_START_MEDIUM		= 40f;
	public const float TIME_START_DIFFERENCE 	= 15f; // 15s more in easy mode, 15s less in hard mode

	// Game modes
	public const int GAME_MODE_UNLIMITED 		= 1;
	public const int GAME_MODE_CAMPAIGN 		= 2;

	// Start level 
	public const int START_LEVEL				= 1;

	// Time to attribute the stars
	public const int TIME_3STARS				= 8;
	public const int TIME_2STARS				= 14;
	public const int TIME_1STARS				= 20;
}

//////////////////////////////////////////////////////////////////////////////////
///  All game type definitions
//////////////////////////////////////////////////////////////////////////////////

public struct posInEchiquier_t {
	public int x;
	public int y;

	// Constructor:
	public posInEchiquier_t(int xx, int yy) 
	{
		this.x = xx;
		this.y = yy;
	}
}
