using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    public float speed = 4.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    //private Animator animator;


    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //

    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;

        /*animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);
        animator.SetFloat("Speed", input.sqrMagnitude);*/


    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }

}
