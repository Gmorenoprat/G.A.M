using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choripan : MonoBehaviour
{
    public float shootForce;
    public AudioSource EatSound;
    public Rigidbody2D rb;
    public float durationTime = 5f;

    public int damage = 20;


    private Color alphaColor;
    private float timeToFade = 2f;
    private float timeToDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        EatSound=GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
    }

    private void Update()
    {
        //Desaparece despues de durationTime
        durationTime -= Time.deltaTime;
        if (durationTime <= 0)
        {
            this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, alphaColor, timeToFade * Time.deltaTime);
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 15) //gorila
        {
            EatSound.Play();
            collision.gameObject.GetComponent<DestroyableComp>().getDamage(this.damage);
            GameObject.Destroy(this.gameObject);
        }
        if(collision.gameObject.layer == 14) //pinguino
        {
            EatSound.Play();
            collision.gameObject.GetComponent<DestroyableComp>().getHealth(this.damage);
            GameObject.Destroy(this.gameObject);
        }
    }


}
