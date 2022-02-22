using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public int[] quantity;
	public Item[] items;

	public int AddItemToInventory(Item item)
	{
		//Cycle through each inventory slot
		for (int i = 0; i < items.Length; i++)
		{
			//If the slot is NOT empty
			if (quantity[i] > 0)
			{
				//If the slot is not at max capacity AND the item in the slot is the same as the new item
				if (quantity[i] < items[i].maxStack && item.Equals(items[i]))
				{
					//Increase the UI text for the slot by 1

					//Update the quantity list
					FindObjectOfType<AudioManager>().Play("PickupItem");
					quantity[i]++;
					return i;

					//UPDATE SCORE#####################
				}
			}
			//If the slot is empty
			else
			{
				//Update the quantity list and add the item to the items list

				//UPDATE SCORE###########################

				quantity[i]++;
				items[i] = item;
				AddButtonToSlot(item, i);
				FindObjectOfType<AudioManager>().Play("PickupItem");
				return i;
			}
		}
		return -1;
	}

	public void RemoveItemFromInventory()
	{

	}

	private void AddButtonToSlot(Item item, int i)
	{
		//Create the button on the UI
		Instantiate(item.itemButton, GameObject.Find("Slot (" + i + ")").transform);
	}


}
