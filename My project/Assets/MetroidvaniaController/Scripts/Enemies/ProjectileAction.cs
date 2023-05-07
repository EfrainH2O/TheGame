using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAction : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 direction;
    private Vector3 position;

    public GameObject baseBullet;
    private bool shoot;

    private Quaternion rotation;
    public float TimeBetweenShoots;

    void Start()
    {
        shoot = true;
        if( direction.x > 0 ) { position = new Vector3(transform.position.x + transform.localScale.x * 1.3f, transform.position.y  , 0); }
        if (direction.x < 0) { position = new Vector3(transform.position.x - transform.localScale.x * 1.3f, transform.position.y, 0); }
        if (direction.y > 0) { position = new Vector3(transform.position.x , transform.position.y + transform.localScale.y * 1.8f, 0); }
        if (direction.y < 0) { position = new Vector3(transform.position.x , transform.position.y - transform.localScale.y * 1.8f, 0); }

        rotation = transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {
       
            
        if (shoot)
        {
           
            
            shoot = false;
            GameObject bullet = Instantiate ( baseBullet , position, rotation ) as GameObject;
            bullet.GetComponent<EnemyProjectile>().direction = direction;
            bullet.name = "Bullet";
            StartCoroutine(Cooldown(TimeBetweenShoots));
        }
    }


    IEnumerator Cooldown(float delay) {
        yield return new WaitForSeconds(delay);
        shoot = true;
    }
}

