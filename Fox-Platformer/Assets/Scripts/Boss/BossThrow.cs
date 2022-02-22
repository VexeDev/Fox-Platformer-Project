using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrow : StateMachineBehaviour
{
	//Detection
	public float attackRadius;
	public LayerMask playerMask;

	//Attacking
	private Transform attackPoint;
	public GameObject rockPrefab;
	public float bulletForce = 10f;
	public int bossDamage;

	private float bossToPlayer;
	private GameObject player;
	private GameObject boss;

	//Attack Cooldown
	public float coolDownTime;
	private float timer;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timer = coolDownTime;
		attackPoint = GameObject.Find("Firepoint").transform;
		player = GameObject.FindGameObjectWithTag("Player");
		boss = GameObject.FindGameObjectWithTag("Boss");
		AttackPlayer();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Collider2D results = Physics2D.OverlapCircle(animator.gameObject.transform.position, attackRadius, playerMask);
		if (results == null)
		{
			Debug.Log("boss out of range of player");
			animator.SetBool("isAttacking", false);
			animator.SetBool("isFollowing", true);
		}

		timer -= Time.deltaTime;
		if (timer <= 0) AttackPlayer();
	}

	private void AttackPlayer()
	{
		Debug.Log("Attacking");
		GameObject bullet = Instantiate(rockPrefab, attackPoint.position, attackPoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

		bossToPlayer = player.transform.position.x - boss.transform.position.x;
		if(bossToPlayer < 0) rb.AddForce(-attackPoint.right * bulletForce, ForceMode2D.Impulse);
		else rb.AddForce(attackPoint.right * bulletForce, ForceMode2D.Impulse);

		timer = coolDownTime;
	}
}
