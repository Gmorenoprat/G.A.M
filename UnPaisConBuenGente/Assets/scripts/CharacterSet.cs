﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, horizontal, jumpForce, maxJump, avJump;
    public Vector3 face;
    public bool onAir;
<<<<<<< HEAD
    public DestroyableComp destroyable;
    public Animator Anim_Pinguin;
    public SpriteRenderer MainSprite;

    void Start()
    {
        MainSprite = this.GetComponent<SpriteRenderer>();
        Anim_Pinguin = this.GetComponent<Animator>();
        destroyable = this.GetComponent<DestroyableComp>();
=======

    void Start()
    {
>>>>>>> main
        rb = this.GetComponent<Rigidbody2D>();
        face = this.transform.right;
    }

    void Update()
    {
        if (horizontal < 0)
        {
            MainSprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            MainSprite.flipX = false;
        }
<<<<<<< HEAD

        if (destroyable.life <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

        

        Anim_Pinguin.SetFloat("walk speed", Mathf.Abs(horizontal));
        Anim_Pinguin.SetFloat("jump", rb.velocity.y);
=======
>>>>>>> main
    }

    public void Die()
    {
        Anim_Pinguin.Play("die");
        GameObject.Destroy(this.gameObject);
    }

    public void Move(float dirX)
    {
        horizontal = dirX;

        Vector3 realVelocity;
        realVelocity.x = speed * horizontal;
        realVelocity.y = rb.velocity.y;
        realVelocity.z = 0;

        rb.velocity = realVelocity;

       
    }

    public void Jump()
    {
        if (avJump > 0 && onAir == false)
        {
            Anim_Pinguin.Play("jump");
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            avJump--;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            avJump = maxJump;
            onAir = false;
            this.transform.parent = collision.transform;
            Anim_Pinguin.Play("movement");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onAir = true;
            this.transform.parent = null;
        }
    }
}
