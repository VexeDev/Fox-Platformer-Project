using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("External References :")]
    public Rigidbody2D rb;
    public Animator playerAnimation;
    public AudioManager audioManager;

    #region Running Variables
    [Header("Speed and Direction")]
    public float movementSpeed;
    private float movementX;

    [Header("Foostep Particle System")]
    public ParticleSystem footSteps;
    #endregion

    #region Jumping Variables
    [Header("Variable Jump Height :")]
    public float jumpForce = 20f;
    private bool pressedJump = false;
    private bool releasedJump = false;
    public float gravityScale = 5f;
    
    [Header("Jump Limit :")]
    private bool startTimer = false;
    public float jumpTimeLimit = 0.5f;
    private float timer;

    [Header("Ground Check :")]
    public Transform feet;
    public LayerMask groundLayer;

    [Header("Hang Time :")]
    public float hangTime = .2f;
    private float hangCounter;

    private bool isFlipped;
    #endregion

    private void Awake()
    {
        timer = jumpTimeLimit;
        isFlipped = false;
    }

    private void Update()
	{
		//Take player input for horizontal movement
		movementX = Input.GetAxisRaw("Horizontal");

        //Call Handler functions
        HandleJump();
        HandleAnimation();
        HandleFootEmission();
        HandleFlipPlayer();
    }

	private void HandleFlipPlayer()
	{
        if (movementX > 0 && isFlipped)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isFlipped = false;
        }
        else if (movementX < 0 && !isFlipped)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isFlipped = true;
        }
	}

	private void FixedUpdate()
	{
        //Call Handler functions
		HandleRun();

        //New Jump
        if (pressedJump) StartJump();
		if (releasedJump) StopJump();
	}

	#region Handler Functions
	private void HandleRun()
	{
		Vector2 movement = new Vector2(movementX * movementSpeed, rb.velocity.y);
		rb.velocity = movement;
        //if(Mathf.Abs(movementX) > 0) FindObjectOfType<AudioManager>().Play("Footstep"); //Something wrong here?
    }

	private void HandleJump()
	{
        //Hang time implementation
        if (IsGrounded()) hangCounter = hangTime;
        else hangCounter -= Time.deltaTime;

        //Take player input and jump
        if (Input.GetButtonDown("Jump") && hangCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);

        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) releasedJump = true;
        }
    }

	private void HandleAnimation()
	{
        playerAnimation.SetFloat("Speed", Mathf.Abs(movementX));
        //playerAnimation.SetFloat("jumpVelocity", rb.velocity.y);
        playerAnimation.SetBool("isJumping", !IsGrounded());
    }

	private void HandleFootEmission()
	{
		var footEmission = footSteps.emission;

		//Enable footstep particle system if the player is moving and not jumping
		if (movementX != 0 && IsGrounded()) footEmission.rateOverTime = 35f;
		else footEmission.rateOverTime = 0f;
	}
    #endregion


	//Check if player is on the ground
	public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.05f, groundLayer);
        return groundCheck != null;
    }

    #region Jumping Methods
    //Start the jump when button is pressed
    private void StartJump()
    {
        rb.gravityScale = 0f;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
    }

    //Stop the jump the button is released
    private void StopJump()
    {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimeLimit;
        startTimer = false;
    }
    #endregion

    public void SpeedBuff()
	{
        movementSpeed *= 2;
        StartCoroutine(SpeedBuffOff());
	}

    IEnumerator SpeedBuffOff()
	{
        yield return new WaitForSeconds(10f);
        movementSpeed /= 2;

	}
}
