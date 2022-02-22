using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
	private WeaponController weaponController;
	private Inventory inventory;
	public TMP_Text quantityText;
	public int i;

	private void Awake()
	{
		//Turn off the stack counter
		quantityText.gameObject.SetActive(false);
		//Assign variables
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		weaponController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
	}

	private void Update()
	{
		HandleStackCounter();
		HandleItemButton();
	}

	//Updates the stack counter for the inventory slot
	private void HandleStackCounter()
	{
		//If the inventory slot is filled and the stack counter is off, turn the stack counter on.
		if (inventory.quantity[i] > 0 && !quantityText.gameObject.activeSelf) quantityText.gameObject.SetActive(true);

		quantityText.text = inventory.quantity[i].ToString();

	}

	//Updates the itemButton in the inventory slot
	private void HandleItemButton()
	{
		if (inventory.quantity[i] < 1)
		{
			quantityText.gameObject.SetActive(false);

			if (transform.childCount > 1)
			{
				foreach (Transform child in transform)
				{
					if (child.CompareTag("ItemButton"))
					{
						GameObject.Destroy(child.gameObject);
					}
				}
			}

		}
	}

	public void DropItem()
	{
		if(inventory.quantity[i] > 0)
		{
			GameObject x = GetComponentInChildren<InventoryButtonScript>().correspondingItem.spawnedObject;
			for (int lp = 0; lp < inventory.quantity[i]; lp++)
			{
				if(x.CompareTag("Weapon"))
				{
					weaponController.DeactivateAllWeapons();
				}
				Debug.Log("made pitem for dropped item");
				Instantiate(x, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(1, 1, 0), Quaternion.identity);
				FindObjectOfType<AudioManager>().Play("DropItem");
			}

			inventory.quantity[i] = 0;
		}
		
	}
}
