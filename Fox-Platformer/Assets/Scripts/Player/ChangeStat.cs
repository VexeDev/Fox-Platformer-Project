using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStat : MonoBehaviour
{
    public GameObject eventSystem;

    [Header("Type")]
    public bool boost;
    public bool drop;

    public bool destroyOnUse;

    [Header("Boost Properties")]
    public bool health;

    public int amount;

    [Header("Other")]
    public bool scoreAdd;
    public int amountScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (boost == true)
            {
                //boost for each property here
                if (health == true)
                {
                    collision.GetComponent<PlayerHealth>().Heal(amount);
                }

                if (scoreAdd == true)
                {
                    eventSystem.GetComponent<Score>().AddPoints(amountScore);
                }
            } else if (drop == true)
            {
                //drop the stat for each property here
                if (health == true)
                {
                    collision.GetComponent<PlayerHealth>().TakeDamage(amount);
                }
            }
        }
        if(destroyOnUse == true)
        {
            Destroy(this.gameObject);
        }
    }
}
