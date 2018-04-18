using UnityEngine;
using System.Collections;

public class carafeFinalObject {

	// Members
	private	int internalColor; 
	private int internalVolume;
	private int internalType;
//	private int internalVolumeMultiplier;

	//////////////////////////////////////////////////////////////////////////////////
	// Constructor
	//////////////////////////////////////////////////////////////////////////////////
	/// 
	public carafeFinalObject (int color, int volume, int type/*, int volumeMultiplier*/)
	{
		internalColor = color;
		internalVolume = volume;
		internalType = type;
//		internalVolumeMultiplier = volumeMultiplier;
	}
	
	//////////////////////////////////////////////////////////////////////////////////
	// methods
	//////////////////////////////////////////////////////////////////////////////////

	// Fill the final Carafe
	// Return = remaining volume
	public int loadCarafe(int volumeToLoad, int colorToLoad) {
		// MANAGE NEW COLOR according to COLORING RULES
		internalColor = ColoringRulesClass.ColoringRules (internalVolume, internalColor, colorToLoad);
		
		// Set volume only after changing color as it influences the color if Volume is EMPTY
		return fullingRules(internalVolume, volumeToLoad);
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Getter / Setter
	//////////////////////////////////////////////////////////////////////////////////

	// Color
	public int getCarafeColor() {
		return internalColor;
	}
	
	public void setCarafeColor(int val) {
		internalColor = val;
	}

	// volume
	public int getCarafeVolume() {
		return internalVolume;
	}
	
	public void setCarafeVolume(int val) {
		internalVolume = val;
	}

	// Color
	public int getCarafeType() {
		return internalType;
	}

	public void setCarafeType(int val) {
		internalType = val;
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Private methods
	//////////////////////////////////////////////////////////////////////////////////
	
	// Get the new volume and remaining volume
	private int fullingRules (int currentVolume, int newVolume) {
		int resultVolume = 0;
		int rest = 0;

		// MANAGE VOLUME
		resultVolume = internalVolume + newVolume;
		if (resultVolume > 4) {
			// Rest is resultVolume without full volume
			rest = resultVolume - 4;
			// Recipient is full
			resultVolume = 4;
		}
		
		internalVolume = resultVolume;
		
		return rest;
	}
}
