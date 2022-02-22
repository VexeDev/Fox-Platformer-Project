using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStomp : StateMachineBehaviour
{
	private Transform playerPos;
	public float speed;

	public float attackRadius;
	public LayerMask playerMask;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

		Collider2D results = Physics2D.OverlapCircle(animator.gameObject.transform.position, attackRadius, playerMask);
		if (results != null)
		{
			Debug.Log("boss attacks player");
			animator.SetBool("isAttacking", true);
			animator.SetBool("isFollowing", false);

		}
	}
}

