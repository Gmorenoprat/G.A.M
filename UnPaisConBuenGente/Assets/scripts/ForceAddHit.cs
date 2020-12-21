using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAddHit : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14 || collision.gameObject.layer == 15)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce
                ((this.gameObject.transform.up + Vector3.up) * 120, ForceMode2D.Impulse);
            
        }
    }

   /*public void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce
            (this.gameObject.transform.up * 80, ForceMode2D.Impulse);
    }*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
