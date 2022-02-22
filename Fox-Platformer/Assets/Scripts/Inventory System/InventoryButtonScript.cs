using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{
	public Item correspondingItem;
	private Inventory inventory;
	private PlayerHealth playerHealth;
	private WeaponController weaponController;
	private PlayerMovement playerMovement;
	private int i;

	private void Awake()
	{
		//Assign variables
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		weaponController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		i = GetComponentInParent<Slot>().i;
	}


	#region Methods called by buttons
	//Used by weapon items in inventory
	public void SetWeaponInUse(int weaponNum)
	{
		weaponController.ActivateWeapon(weaponNum);
	}

	//Used by health potion items in inventory
	public void ConsumeHealthPotion()
	{
		//Interface with health system
		playerHealth.Heal(25);
		FindObjectOfType<AudioManager>().Play("ConsumePotion");
		Debug.Log("Healed");
	}

	public void ConsumeSpeedPotion()
	{
		//Interface with movement system
		playerMovement.SpeedBuff();
		FindObjectOfType<AudioManager>().Play("ConsumePotion");
		Debug.Log("Speed Increased");
	}


	#endregion

	public void UseObject()
	{
		inventory.quantity[i]--;
	}
}
