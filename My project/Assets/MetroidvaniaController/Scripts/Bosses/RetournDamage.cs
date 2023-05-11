using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetournDamage : MonoBehaviour
{
    public bool isHit;
    private GameObject boss;
    // Update is called once per frame
    void Start()
    {
        isHit = false;
        boss = GameObject.Find("IceQueen");
    }

    void Update()
    {
        if (isHit)
        {
            transform.position = Vector2.MoveTowards(transform.position, boss.transform.position,  5);
        }
    }

    public void ApplyDamage(float damage)
    {
        isHit = true;
        gameObject.GetComponent<BouncyBall>().enabled = false;
    }


}
