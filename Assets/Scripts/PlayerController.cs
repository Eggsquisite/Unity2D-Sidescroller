using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 200;      // player left/right walk speed
    public float jumpSpeed = 200;
    private bool isGrounded = true;    // is player on the ground?

    Animator animator;
    private Rigidbody2D body;

    // flags to check for specific animations
    bool isPlaying_crouch = false;
    bool isPlaying_jump = false;
    bool canRunLeft = true;
    bool canRunRight = true;

    // animation states
    const int STATE_IDLE = 0;
    const int STATE_HURT = 1;
    const int STATE_RUN = 2;
    const int STATE_CROUCH = 3;
    const int STATE_JUMP = 4;
    const int STATE_CLIMB = 5;

    string currentDirection = "right";
    int currentAnimationState = STATE_IDLE;
    int currentSceneIndex;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        body = this.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        // Play Jump animation and make character jump
        if (Input.GetKeyDown(KeyCode.W) && !isPlaying_crouch)
        {
            // Jump
            if (isGrounded)
            {
                isGrounded = false;
                body.AddForce(new Vector2(0, jumpSpeed));
                changeState(STATE_JUMP);
            }
        }
        // Crouch
        else if (Input.GetKey(KeyCode.S) && isGrounded && !isPlaying_jump)
        {
            changeState(STATE_CROUCH);
        }
        // Run Right
        else if (Input.GetKey(KeyCode.D) && !isPlaying_crouch)
        {
            if (isGrounded)
                changeState(STATE_RUN);

            // move character to right
            changeDirection("right");
            // check if character runs into wall
            if(canRunRight)
                body.transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        }
        // Run Left
        else if (Input.GetKey(KeyCode.A) && !isPlaying_crouch)
        {
            if (isGrounded)
                changeState(STATE_RUN);

            // move character to left
            changeDirection("left");
            // check if character runs into wall
            if(canRunLeft)
                body.transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        }
        else
        {
            if (isGrounded)
                changeState(STATE_IDLE);
        }

        // check for crouch anim
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Crouch"))
            isPlaying_crouch = true;
        else
            isPlaying_crouch = false;

        // check for jump anim
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump"))
            isPlaying_jump = true;
        else
            isPlaying_jump = false;
    }

    void changeState(int state)
    {
        if (currentAnimationState == state)
            return;

        switch (state)
        {
            case STATE_IDLE:
                animator.SetInteger("state", STATE_IDLE);
                break;

            case STATE_HURT:
                animator.SetInteger("state", STATE_HURT);
                break;

            case STATE_RUN:
                animator.SetInteger("state", STATE_RUN);
                break;

            case STATE_CROUCH:
                animator.SetInteger("state", STATE_CROUCH);
                break;

            case STATE_JUMP:
                animator.SetInteger("state", STATE_JUMP);
                break;

            case STATE_CLIMB:
                animator.SetInteger("state", STATE_CLIMB);
                break;
        }

        currentAnimationState = state;
    }

    // Check to see if grounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isGrounded = true;
            changeState(STATE_IDLE);
        }

        if (collision.gameObject.name == "WavySprite")
            SceneManager.LoadScene("Lose");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall_Left" && canRunRight)
            canRunLeft = false;

        if (collision.gameObject.name == "Wall_Right" && canRunLeft)
            canRunRight = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if stopped running into a left wall, resume movement
        if (collision.gameObject.name == "Wall_Left")
            canRunLeft = true;

        if (collision.gameObject.name == "Wall_Right")
            canRunRight = false;
    }

    // Flip player sprite corresponding to direction walking
    void changeDirection(string direction)
    {
        if (currentDirection != direction)
        {
            if (direction == "right")
            {
                transform.Rotate(0, 180, 0);
                currentDirection = "right";
            }
            else if (direction == "left")
            {
                transform.Rotate(0, -180, 0);
                currentDirection = "left";
            }
        }
    }
}
