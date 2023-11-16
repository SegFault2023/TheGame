using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    Animator anim;
    public float speed = 0.5f;
    public Rigidbody2D rb;

    private Vector2 lastMovedDirection;
    private Vector2 input;
    private bool facingLeft = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ProccessInput();
        Animate();
        if(input.x < 0 && !facingLeft || input.x > 0 && facingLeft)
        {
            Flip();
        }
    }


    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }


    private void ProccessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            lastMovedDirection = input;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");


        

        input.Normalize();
    }


    private void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMovedDirection.x);
        anim.SetFloat("LastMoveY", lastMovedDirection.y);
        
    }
}
