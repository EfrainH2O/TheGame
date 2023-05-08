using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectShoot : MonoBehaviour
{


    public GameObject baseBullet;
    private GameObject Player;
    private Vector3 position;
    private Quaternion rotation;
    private Vector2 direction;
    public float TimeBetweenShoots;
    private bool shoot;



    void Start()
    {
        Player = GameObject.Find("DrawCharacter"); 
        shoot = true;
    }
    


    void Update()
    {

        if (shoot)
        {
            position = transform.position;
            rotation = transform.rotation;
            setDirection();
            shoot = false;
            GameObject bullet = Instantiate(baseBullet, position, rotation) as GameObject;
            bullet.GetComponent<EnemyProjectile>().direction = direction;
            bullet.name = "Bullet";
            StartCoroutine(Cooldown(TimeBetweenShoots));
        }
    }


    IEnumerator Cooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        shoot = true;
    }

    void setDirection()
    {
        direction = new Vector3(Player.transform.position.x - position.x, Player.transform.position.y - position.y, 0);
    }
}
