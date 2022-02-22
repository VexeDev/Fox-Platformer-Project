using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
	public Item item;

	private Inventory inventory;

	private void Awake()
	{
		//Assign the inventory variable to the player's inventory
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	//When the player collides with the physical item, add it to their inventory
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//Try to add the item to the inventory. If successful, destroy the physical item.
			int c = inventory.AddItemToInventory(item);
			if (c > -1)
			{
				Destroy(gameObject);
			}
		}
	}
}
