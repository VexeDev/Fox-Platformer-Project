using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    public int enemyDamage;
    //public GameObject deathEffect;

    private PlayerHealth phs;
    private PlayerMovement pms;

    GameObject eventSystem;

    public GameObject platformFinal;

    bool canDamage = true;
    public float cooldownTime = 1f;

	private void Awake()
	{
        phs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        pms = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        eventSystem = GameObject.FindGameObjectWithTag("EventSystem");
	}

	public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Destroy(effect, .2f);

        //score
        eventSystem.GetComponent<Score>().AddPoints(20);
        //boss special
        if(gameObject.name == "Boss")
        {
            platformFinal.SetActive(true);
            eventSystem.GetComponent<Score>().AddPoints(80);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && canDamage == true)
		{
			phs.TakeDamage(enemyDamage);
            canDamage = false;
            StartCoroutine(DamageCooldown());
			//StartCoroutine(pms.Knockback(this.transform));
		}
	}

    public IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canDamage = true;
    }
}
