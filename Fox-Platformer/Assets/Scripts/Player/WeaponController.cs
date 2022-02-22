using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weapons;

	private void Awake()
	{
		DeactivateAllWeapons();
	}

	public void ActivateWeapon(int weaponNum)
	{
		DeactivateAllWeapons();
		weapons[weaponNum].SetActive(true);
	}

	public void DeactivateAllWeapons()
	{
		foreach( GameObject w in weapons)
		{
			w.SetActive(false);
		}
	}
}
