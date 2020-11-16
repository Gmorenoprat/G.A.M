using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyableComp : MonoBehaviour
{
    public float life;
    public TextMeshPro vidaTextMesh;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        DestructorComp Destructor = collision.gameObject.GetComponent<DestructorComp>();
        if (Destructor != null)
        {
            getDamage( Destructor.damage );
        }
        if (life <= 0)
        {
            GameObject.Destroy(this.gameObject);
            FindObjectOfType<conditionWiner>().lifeDown(gameObject);
        }
    }

    public void getDamage(int dmg)
    {
        life -= dmg;
        DamagePopup.Create(transform.position, dmg, true);
        vidaTextMesh.text = life.ToString();
    }

    public void getHealth(int hp)
    {
        life += hp;
        DamagePopup.Create(transform.position, hp , false);
        vidaTextMesh.text = life.ToString();
    }
}
