using UnityEngine;
using System.Collections;

public static class ColoringRulesClass {
	// Get the result color (COLORING rules)
	public static int ColoringRules (int currentVolume, int currentColor, int newColor) {

		// If current is full, no coloring rules
		if (currentVolume == AllGameParameters.VOLUME_1)
			return currentColor;

		// If current is empty, take new color
		if (currentVolume == AllGameParameters.VOLUME_0)
			return newColor;

		// With BLACK, everything stays BLACK
		if ((currentColor == AllGameParameters.CARAFE_BLACK) || (newColor == AllGameParameters.CARAFE_BLACK))
			return AllGameParameters.CARAFE_BLACK;

		// With WHITE, color stays as it is
		if (currentColor == AllGameParameters.CARAFE_WHITE)
			return newColor; 
		if (newColor == AllGameParameters.CARAFE_WHITE)
			return currentColor;

		// if Red & Blue => Green
		if ((currentColor == AllGameParameters.CARAFE_RED) && (newColor == AllGameParameters.CARAFE_BLUE))
			return AllGameParameters.CARAFE_GREEN;
		if ((currentColor == AllGameParameters.CARAFE_BLUE) && (newColor == AllGameParameters.CARAFE_RED))
			return AllGameParameters.CARAFE_GREEN;

		// if Red & Green => Blue
		if ((currentColor == AllGameParameters.CARAFE_RED) && (newColor == AllGameParameters.CARAFE_GREEN))
			return AllGameParameters.CARAFE_BLUE;
		if ((currentColor == AllGameParameters.CARAFE_GREEN) && (newColor == AllGameParameters.CARAFE_RED))
			return AllGameParameters.CARAFE_BLUE;

		// if Blue & Green => Red
		if ((currentColor == AllGameParameters.CARAFE_BLUE) && (newColor == AllGameParameters.CARAFE_GREEN))
			return AllGameParameters.CARAFE_RED;
		if ((currentColor == AllGameParameters.CARAFE_GREEN) && (newColor == AllGameParameters.CARAFE_BLUE))
			return AllGameParameters.CARAFE_RED;

		// color are the same, keep it
		if (currentColor == newColor)
		    return currentColor;

		// Normally, may never come here
		return AllGameParameters.CARAFE_WHITE;
	}
}
