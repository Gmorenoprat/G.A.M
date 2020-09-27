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

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(avShoot > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            avShoot--;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!exp)
        {
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
        }
    }
}
