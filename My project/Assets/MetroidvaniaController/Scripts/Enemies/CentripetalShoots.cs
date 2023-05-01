using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentripetalShoots : MonoBehaviour
{

    public GameObject baseBullet;
    public Rotation mRotation;
    private Vector3 position;
    private Quaternion rotation;
    private Vector2 direction;
    public float TimeBetweenShoots;
    private bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = true;
    }


    void Update()
    {

        if (shoot)
        {
            position = transform.position;
            rotation = mRotation.transform.rotation;
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

    public void setDirection()
    {
        direction = new Vector2(- mRotation.transform.position.x + position.x, - mRotation.transform.position.y + position.y);
    }
}
