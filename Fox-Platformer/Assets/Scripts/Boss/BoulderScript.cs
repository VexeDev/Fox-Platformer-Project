using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
	public int rangedDamage = 20;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Boss hit player");
			collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(rangedDamage);
			Destroy(gameObject);
		}

		StartCoroutine(DestroyBoulder());
	}

	IEnumerator DestroyBoulder()
	{
		yield return new WaitForSeconds(4.5f);
		Destroy(gameObject);
	}
}
