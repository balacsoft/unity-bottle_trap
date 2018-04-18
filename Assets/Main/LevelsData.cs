using UnityEngine;
using System.Collections;

public class LevelsData : MonoBehaviour {

	/*
	new caseObject (true, new carafeObject (x, 1, y, new posInEchiquier_t (1, 1), 1)), 		// WATER (Red=1, Blue=2, Green=3, White=4, black=5)
	new caseObject (true, new carafeObject (4, 2, -1, new posInEchiquier_t (1, 1), 1)), 	// ACID
	new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
	new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),		// Empty 
	*/

	public caseObject[,,] theLevelCases = new caseObject[,,]
	{
		// LEVEL 1
		{
			{
				//                                     COLOR TYPE VOLUME POSITION GRAPHIC
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 2
		{
			{
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 3
		{
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 2, -1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 4
		{
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 5
		{
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 6
		{
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 7
		{
			{
				new caseObject (true, new carafeObject (1, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 8
		{
			{
				new caseObject (true, new carafeObject (3, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 9
		{
			{
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 10
		{
			{
				new caseObject (true, new carafeObject (3, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 2, -1, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 11
		{
			{
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 2, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 2, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (2, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 3, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (3, 1, 3, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (3, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (2, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 1, 4, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 4, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 12
		{
			{
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)), 		// White
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1))		// White
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (5, 1, 1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (4, 2, -1, new posInEchiquier_t (1, 1), 1)),
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
		},	
		// LEVEL 13
		{
			{
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)),		// 1/4 Red
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),		// Empty
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1))
			},
		},
		// LEVEL 14
		{
			{
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)),		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (2, 1, 2, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)) 		// WALL
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)),		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (3, 1, 2, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 2, -1, new posInEchiquier_t (1, 1), 1)), 	// ACID
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)) 		// WALL
			},
			{
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)),		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1))
			},
		},		
		// LEVEL 15
		{
			{
				new caseObject (true, new carafeObject (2, 1, 1, new posInEchiquier_t (1, 1), 1)),		
				new caseObject (true, new carafeObject (1, 1, 1, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)) 		
			},
			{
				new caseObject (true, new carafeObject (3, 1, 1, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)),		
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)) 		// WALL
			},
			{
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)), 	
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (5, 1, 3, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1))
			},
			{
				new caseObject (true, new carafeObject (4, 1, 1, new posInEchiquier_t (1, 1), 1)), 	
				new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1)), 		
				new caseObject (true, new carafeObject (5, 1, 4, new posInEchiquier_t (1, 1), 1))
			},
		}	
	};

	/*
	new caseObject (true, new carafeObject (x, 1, y, new posInEchiquier_t (1, 1), 1)), 		// WATER (Red=1, Blue=2, Green=3, White=4, black=5)
	new caseObject (true, new carafeObject (4, 2, -1, new posInEchiquier_t (1, 1), 1)), 	// ACID
	new caseObject (true, new carafeObject (4, 3, 0, new posInEchiquier_t (1, 1), 1)), 		// WALL
	new caseObject (true, new carafeObject (1, 1, 0, new posInEchiquier_t (1, 1), 1)),		// Empty 
	*/

	public carafeFinalObject[] theFinalCarafeLevel = new carafeFinalObject[]
	{
		// COLOR VOLUME TYPE
		// LEVEL 1 - check volume
		new carafeFinalObject(1, 2, 1),
		// LEVEL 2 - check color
		new carafeFinalObject(3, 2, 1),
		// LEVEL 3 - check acid
		new carafeFinalObject(2, 1, 1),
		// LEVEL 4 - check walls
		new carafeFinalObject(3, 3, 1),
		// LEVEL 5 - check diminution
		new carafeFinalObject(1, 1, 1),
		// LEVEL 6 - easy trap
		new carafeFinalObject(2, 4, 1),
		// LEVEL 7 - black boxes
		new carafeFinalObject(1, 1, 1),
		// LEVEL 8 - White boxes
		new carafeFinalObject(3, 4, 1),
		// LEVEL 9 - trip
		new carafeFinalObject(2, 3, 1),
		// LEVEL 10 - acid & black
		new carafeFinalObject(2, 1, 1),
		// LEVEL 11 - Rainbow
		new carafeFinalObject(2, 1, 1),
		// LEVEL 12 - White is white
		new carafeFinalObject(1, 4, 1),
		// LEVEL 13 - No Green
		new carafeFinalObject(3, 4, 1),
		// LEVEL 14 - Breaking the wall
		new carafeFinalObject(1, 3, 1),
		// LEVEL 15 - Black Hole
		new carafeFinalObject(2, 3, 1),
	};

	// Use this for initialization
	void Start () {
	}

}
