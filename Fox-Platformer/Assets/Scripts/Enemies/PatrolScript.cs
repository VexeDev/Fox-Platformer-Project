using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public bool isOnTinyPlatform = false;
    private bool hitPlayer = false;

    public Transform groundCheck;

    private bool isFacingRight = true;

    RaycastHit2D hit;

    public float knockBackDuration = .5f;
    public float knockBackPower = 2f;

    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

    private void FixedUpdate()
    {
        if (!isOnTinyPlatform && !hitPlayer)
        {
            if (hit.collider)
            {
                if (isFacingRight) rb.velocity = new Vector2(speed, rb.velocity.y);
                else rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Player") StartCoroutine(PauseMovement());
        //else if(collision.transform.gameObject.tag == "Enemy") 
        //if(collision.transform.gameObject.tag == "Player") StartCoroutine(Knockback(collision.transform));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    IEnumerator PauseMovement()
    {
        hitPlayer = true;
        yield return new WaitForSeconds(.5f);
        hitPlayer = false;
    }

    //public IEnumerator Knockback(Transform obj)
    //{
    //    float timer = 0;
    //    Time.timeScale = .4f;

    //    while (knockBackDuration > timer)
    //    {
    //        timer += Time.deltaTime;
    //        Vector2 direction = (obj.transform.position - this.transform.position).normalized;
    //        if (direction.y >= -.01) direction.y = direction.y * 5f;
    //        if (direction.y < 0) direction.y /= 10f;
    //        rb.AddForce(-direction * knockBackPower);

    //    }

    //    Time.timeScale = 1f;
    //    yield return 0;
    //}
}
