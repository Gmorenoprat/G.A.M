using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExplosionForce : MonoBehaviour {
	public float forceExplotion = 2000;
	public float radius = 1;
	public float upliftModifer = 500;

    public void Start()
    {
        Vector3 position = this.GetComponent<Transform>().position;

        StartCoroutine(waitAndExplode(position));

    }

	private IEnumerator waitAndExplode(Vector3 position)
    {

        yield return new WaitForSeconds(0.05f);

		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);

        foreach (Collider2D col in colliders)
        {
            // the force will be a vector with a direction from origin to collider's position and with a length of 'forceMultiplier'
            Vector2 force = (col.transform.position - position) * forceExplotion;
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(force);

        }
        yield return null;
	}


}
