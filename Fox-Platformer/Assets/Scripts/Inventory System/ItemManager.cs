using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemManager
{
	public Item[] allItems;

	//public GameObject GetPhysicalObjectForItem(GameObject enemyKilled)
	//{
	//		Possible extension: When the player kills an enemy, a weapon or potion is dropped.
	//}


	//Get a block from allItems based on block ID
	public Item GetBlock(int id)
	{
		foreach (Item b in allItems)
		{
			if (b.itemID == id) return b;
		}
		return null;
	}

	//Simplify the name of a tile down to the specific type (Caves, Desert, Grassland, RedCity)
	private string CleanString(string x)
	{
		return x.Substring(6, x.IndexOf("Original") - 12);
	}
}
