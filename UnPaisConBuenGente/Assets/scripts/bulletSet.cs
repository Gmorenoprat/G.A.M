using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSet : MonoBehaviour
{
    public float shootForce;
    float avShoot = 1;
    bool exp = false;
    public Rigidbody2D rb;
    public GameObject explotionRad;
    public GameObject explotionAnim;
    SpriteRenderer bulletSprite;
    public bool thisMolo;
    public GameObject spawn1, spawn2, spawn3, spawn4, spawn5;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bulletSprite = this.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(avShoot > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            avShoot--;
        }
        this.transform.up = rb.velocity.normalized;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        bulletSprite.color = new Color(0,0,0,0);

        if (!exp && thisMolo==false)
        {
            GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            newExplotionAnim.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
        }
        else if (!exp && thisMolo == true)
        {
            //GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            //newExplotionAnim.transform.position = this.transform.position;

            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = spawn1.transform.position;

            GameObject newExplotion2 = GameObject.Instantiate(explotionRad);
            newExplotion2.transform.position = spawn2.transform.position;

            GameObject newExplotion3 = GameObject.Instantiate(explotionRad);
            newExplotion3.transform.position = spawn3.transform.position;

            GameObject newExplotion4 = GameObject.Instantiate(explotionRad);
            newExplotion4.transform.position = spawn3.transform.position;

            GameObject newExplotion5 = GameObject.Instantiate(explotionRad);
            newExplotion5.transform.position = spawn3.transform.position;

            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 2f);
            GameObject.Destroy(newExplotion2.gameObject, 2f);
            GameObject.Destroy(newExplotion3.gameObject, 2f);
            GameObject.Destroy(newExplotion4.gameObject, 2f);
            GameObject.Destroy(newExplotion5.gameObject, 2f);
        }
    }
}
