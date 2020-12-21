using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAddHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce
            (this.gameObject.transform.up * 80, ForceMode2D.Impulse);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce
            (this.gameObject.transform.up * 80, ForceMode2D.Impulse);
    }
}
