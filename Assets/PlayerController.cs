using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 200;      // player left/right walk speed
    private bool isGrounded = true;    // is player on the ground?

    Animator animator;

    // flags to check for specific animations
    bool isPlaying_crouch = false;
    bool isPlaying_run = false;
    bool isPlaying_jump = false;

    // animation states
    const int STATE_IDLE = 0;
    const int STATE_HURT = 1;
    const int STATE_RUN = 2;
    const int STATE_CROUCH = 3;
    const int STATE_JUMP = 4;
    const int STATE_CLIMB = 5;

    string currentDirection = "right";
    int currentAnimationState = STATE_IDLE;
    int testInt = 0;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        // Play Jump animation and make character jump
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying_run && !isPlaying_crouch)
        {
            // Jump
            if (isGrounded)
            {
                //rigidbody2D.AddForce(new Vector2(0, 250));
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
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        }
        // Run Left
        else if (Input.GetKey(KeyCode.A) && !isPlaying_crouch)
        {
            if (isGrounded)
                changeState(STATE_RUN);
            // move character to right
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        }
        else
        {
            if (isGrounded)
                changeState(STATE_IDLE);
        }
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




}
