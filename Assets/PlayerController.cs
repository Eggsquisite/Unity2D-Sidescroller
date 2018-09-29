using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 1;         // player left/right walk speed
    private bool _isGrounded = true;    // is player on the ground?

    Animator animator;

    const int STATE_IDLE = 0;
    const int STATE_HURT = 1;
    const int STATE_RUN = 2;
    const int STATE_CROUCH = 3;
    const int STATE_JUMP = 4;
    const int STATE_CLIMB = 5;

    int currentAnimationState = STATE_IDLE;
    int testInt = 0;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            changeState(testInt);
            testInt++;
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
