using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, horizontal, jumpForce, maxJump, avJump;
    public Vector3 face;
    public bool onAir;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        face = this.transform.right;
    }

    void Update()
    {
        if (horizontal > 0)
        {
            face = this.transform.right;
        }
        else if (horizontal < 0)
        {
            face = this.transform.right * -1;
        }
    }

    public void Die()
    {
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
