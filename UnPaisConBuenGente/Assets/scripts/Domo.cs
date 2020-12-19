using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domo : MonoBehaviour
{
    private bool golpeado = false;
    public Sprite domoRoto;
    public AudioSource sonidoVidrio;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.layer == 10)
        {
            if(golpeado == true)
            {
                sonidoVidrio.Play();
                Destroy(this.gameObject);
                return;
            }
            golpeado = true;
            this.GetComponent<SpriteRenderer>().sprite = domoRoto;
            sonidoVidrio.Play();
        }
    }
}
