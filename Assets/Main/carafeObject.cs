using UnityEngine;
using System.Collections;

public class carafeObject {

	// Members
	private	int internalColor; 
	private int internalType;
	private int internalVolume;
	private posInEchiquier_t internalPos;
	private int internalGraphicalType;

	//////////////////////////////////////////////////////////////////////////////////
	// Constructor
	//////////////////////////////////////////////////////////////////////////////////
	/// 
	public carafeObject (int color, int type, int volume, posInEchiquier_t pos, int graphicalType)
	{
		internalColor = color;
		internalType = type;
		internalVolume = volume;
		internalPos = pos;
		internalGraphicalType = graphicalType;
	}
	
	//////////////////////////////////////////////////////////////////////////////////
	// methods
	//////////////////////////////////////////////////////////////////////////////////

	// Load current recipient with Volume and Color indicated
	// Return = remaining volume
	public int loadCarafe(int volumeToLoad, int colorToLoad) {
		// MANAGE NEW COLOR according to COLORING RULES
		internalColor = ColoringRulesClass.ColoringRules (internalVolume, internalColor, colorToLoad);

		// Set volume only after changing color as it influences the color if Volume is EMPTY
		return fullingRules(internalVolume, volumeToLoad);
	}

	// Unload current recipient with Volume
	// Return = always OK
	public int unloadCarafe(int remaining) {
		internalVolume = remaining;
		return 0;
	}

	//////////////////////////////////////////////////////////////////////////////////
	// Getter / Setter
	//////////////////////////////////////////////////////////////////////////////////
	
	// Type
	public int getCarafeType() {
		return internalType;
	}

	public void setCarafeType(int val) {
		internalType = val;
	}

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

	// position
	public posInEchiquier_t getCarafePos() {
		return internalPos;
	}
	
	public void setCarafePos(posInEchiquier_t val) {
		internalPos = val;
	}
	
	// Graphical Type
	public int getCarafeGraphicalType() {
		return internalGraphicalType;
	}
	
	public void setCarafeGraphicalType(int val) {
		internalGraphicalType = val;
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
