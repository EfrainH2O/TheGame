using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{


	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;
	

	void Start()
	{

	}

	void FixedUpdate()
	{
		if (!hasHit)
			GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);

			Destroy(gameObject);
		}
		else if (collision.gameObject.tag != "Enemy")
		{
			Destroy(gameObject);
		}
	}
}