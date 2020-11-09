using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buitre : MonoBehaviour
{
    public float buitreMaxFlightCount = 100;
    public float flightFroce = 100f;
    public float speed = 10f;
    public float horizontal;
    public SpriteRenderer buitreSprite;

    public FixedJoint2D fixJoint;

    public TextMeshPro flightsTextMesh;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        buitreSprite = this.GetComponent<SpriteRenderer>();
        fixJoint = this.GetComponent<FixedJoint2D>();
        flightsTextMesh.text = buitreMaxFlightCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {


        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            buitreSprite.flipX = true;
        }
        else if (horizontal < 0)
        {
            buitreSprite.flipX = false;
        }

        Move(horizontal);
        if (buitreMaxFlightCount > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * flightFroce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
                buitreMaxFlightCount--;
                flightsTextMesh.text = buitreMaxFlightCount.ToString();
            }
        }

        if(buitreMaxFlightCount <= 0)
        {
            Destroy(fixJoint);
            rb.AddForce(Vector3.up * 1 , ForceMode2D.Impulse);
            Destroy(this.gameObject, 5f);
        }
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
}
