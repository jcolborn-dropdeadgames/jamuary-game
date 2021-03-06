﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : physicObjects {

    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (Mathf.Abs(move.x) > 0) {
            if (move.x < 0) {
                spriteRenderer.flipX = true;
            }
            else if (move.x > 0) {
                spriteRenderer.flipX = false;
            }
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    } // end of overrided ComputeVelocity
}
