using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baston : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(ocultarUnosSegs());
        }
    }

    public  IEnumerator ocultarUnosSegs()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return null;
    }
}