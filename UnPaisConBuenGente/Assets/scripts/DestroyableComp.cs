using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableComp : MonoBehaviour
{
    public float life;

    public void Start()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        DestructorComp Destructor = collision.gameObject.GetComponent<DestructorComp>();
        if (Destructor != null)
        {
            life -= Destructor.damage;
            DamagePopup.Create(transform.position, Destructor.damage);
            if (life <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
