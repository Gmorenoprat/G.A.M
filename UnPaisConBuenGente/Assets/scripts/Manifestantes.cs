using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manifestantes : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce, horizontal, speed, cont, expCont, jumpTime;
    public int direction;
    bool avJump = true, exp=false;

    public string commandShoot;

    public GameObject explotionRad,spawn;
    public GameObject explotionAnim;

    public List<SpriteRenderer> pingusSpriteRend;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction);

        if(cont >= jumpTime)
        {
            Jump();
        }
        cont += Time.deltaTime;

        if(!exp && expCont <= 0)
        {
            GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            newExplotionAnim.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = spawn.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
        }
        expCont -= Time.deltaTime;

        if (!exp && Input.GetButton(commandShoot))
        {
            GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            newExplotionAnim.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = spawn.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
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

    public void Jump()
    {
        if (avJump)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            cont = 0;
            avJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            avJump = true;
        }
    }
}
