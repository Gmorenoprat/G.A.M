using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialExplotionForce : MonoBehaviour
{
    public float radius = 100f;
    public float forceExplotion = 5000f;
    public Vector3 position;


    public void Awake()
    {

        position = this.GetComponent<Transform>().position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);

        foreach (Collider2D col in colliders)
        {
            // the force will be a vector with a direction from origin to collider's position and with a length of 'forceMultiplier'
            Vector2 force = (col.transform.position - position) * forceExplotion;
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(force);

        }
    }
}
