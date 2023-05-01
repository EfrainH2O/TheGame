using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAction : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction;

    private Vector3 position;

    public GameObject baseBullet;
    private bool shoot;

    private Quaternion rotation;

    void Start()
    {
        shoot = true;
        
        position = transform.position + new Vector3( transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);

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
            StartCoroutine(Cooldown(1.3f));
        }
    }


    IEnumerator Cooldown(float delay) {
        yield return new WaitForSeconds(delay);
        shoot = true;
    }
}

