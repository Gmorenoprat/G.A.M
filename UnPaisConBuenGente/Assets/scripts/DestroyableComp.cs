using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableComp : MonoBehaviour
{
    public float life;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        DestructorComp Destructor = collision.gameObject.GetComponent<DestructorComp>();
        if (Destructor != null)
        {
            getDamage( Destructor.damage );
            if (life <= 0)
            {
                FindObjectOfType<conditionWiner>().lifeDown(gameObject);
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    public void getDamage(int dmg)
    {
        life -= dmg;
        DamagePopup.Create(transform.position, dmg, true);
    }

    public void getHealth(int hp)
    {
        life += hp;
        DamagePopup.Create(transform.position, hp , false);
    }
}
