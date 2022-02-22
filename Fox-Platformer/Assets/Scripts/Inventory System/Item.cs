using System;
using UnityEngine;

public enum ItemType
	{
		Potion,
		Weapon,
		Other
	}


[CreateAssetMenu(fileName = "ItemName", menuName = "Item")]
public class Item : ScriptableObject
{
	public ItemType type;
	public int itemID;
	public Sprite itemSprite;
	public int maxStack;
	public GameObject spawnedObject;
	public GameObject itemButton;
}