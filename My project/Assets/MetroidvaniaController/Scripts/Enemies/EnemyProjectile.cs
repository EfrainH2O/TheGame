using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour 
{

	public Vector3 direction;
	public bool hasHit = false;
	

	void Start()
	{

	}

	void Update()
	{
		if (!hasHit)
		{
           
            transform.Translate(direction * Time.deltaTime);
			
		}
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);

			Destroy(gameObject);
		}
		else if (collision.gameObject.tag == "Limits")
		{
			Destroy(gameObject);
		}
	}
}