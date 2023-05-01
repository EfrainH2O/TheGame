using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);
        }
    }
}
