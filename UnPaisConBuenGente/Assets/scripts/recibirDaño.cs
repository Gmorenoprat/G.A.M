using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recibirDaño : MonoBehaviour
{
       public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 10) return;
        DamagePopup.Create(transform.position, 420);
    }
}
