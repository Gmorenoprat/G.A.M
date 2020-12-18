using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granada : MonoBehaviour
{
    public float shootForce;
    public float explotionTime;
    bool exp = false, mineTrigger=false;
    public GameObject explotionRad;
    public GameObject explotionAnim;
    public AudioSource boingSound;
    public Rigidbody2D rb;
    SpriteRenderer granadeSprite;
    public bool isProxMine = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        granadeSprite = this.GetComponent<SpriteRenderer>();
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (explotionTime <= 0 && !exp)
        {
            granadeSprite.color = new Color(0, 0, 0, 0);
            GameObject explotionAnimo = GameObject.Instantiate(explotionAnim);
            explotionAnimo.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
            GameObject.Destroy(this.gameObject, 0.2f);
        }
        
        if(isProxMine == true)
        {
            if (mineTrigger == true)
            {
                explotionTime -= Time.deltaTime;
            }
        }
        else if (isProxMine == false)
        {
            explotionTime -= Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        boingSound.Play(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            mineTrigger = true;
        }
    }
}
