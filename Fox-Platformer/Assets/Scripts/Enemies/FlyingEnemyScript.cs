using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyScript : MonoBehaviour
{
    public float speed, stoppingDistance, retreatDistance, startTimeBetweenShots, detectionRange;
    private float timeBetweenShots;

    private Transform player;
    public GameObject projectile;

    public LayerMask playerLayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(this.transform.position, detectionRange, playerLayer);
        if (playerCollider)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
            {
                transform.position = this.transform.position;
            }
            else if ((Vector2.Distance(transform.position, player.position) < retreatDistance))
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }


            if (timeBetweenShots <= 0 && Vector2.Distance(transform.position, player.position) <= stoppingDistance)
            {
                //FindObjectOfType<AudioManager>().Play("UmbrellaShoot");
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

	private void OnDrawGizmosSelected()
	{
        //Gizmos.DrawSphere(gameObject.transform.position, detectionRange);
	}
}
