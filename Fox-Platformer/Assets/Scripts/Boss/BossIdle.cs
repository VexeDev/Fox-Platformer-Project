using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
{
	public float radius;
	public LayerMask playerMask;

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Collider2D results = Physics2D.OverlapCircle(animator.gameObject.transform.position, radius, playerMask);
		if (results != null)
		{
			animator.SetBool("isFollowing", true);
			Debug.Log("boss detects player");
		}
	}
}
