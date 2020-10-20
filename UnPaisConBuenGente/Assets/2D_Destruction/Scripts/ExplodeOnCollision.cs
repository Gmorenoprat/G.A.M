using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnCollision : MonoBehaviour
{
	public bool collisionan2 = false;
	private Explodable _explodable;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}
	//void OnMouseDown()
	//{
	//	_explodable.explode();
	//	ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
	//	ef.doExplosion(transform.position);
	//}

	// called when the cube hits the floor
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer != 10) return;
		_explodable.explode();
		collisionan2 = true;
	}

	private void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.layer != 10) return;
		_explodable.explode();
		collisionan2 = true;
	}
}
