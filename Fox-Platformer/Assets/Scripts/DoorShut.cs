using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShut : MonoBehaviour
{
    public GameObject door;

    public GameObject otherTrigger;

    public GameObject boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            door.GetComponent<Animator>().SetBool("shut", true);

            //spawn enemies
            boss.SetActive(true);
            //disable other trigger and itself
            otherTrigger.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
