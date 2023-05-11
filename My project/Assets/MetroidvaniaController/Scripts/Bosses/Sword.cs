using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{


    // Start is called before the first frame update
    private GameObject IceQueen;

    void Start()
    {
        IceQueen = GameObject.Find("IceQueen");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Swing()
    {
        //transform.GetComponent<Animator>().SetBool("Slash", true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }

    public void EndSwing()
    {
        IceQueen.GetComponent<IceQueenMainCommand>().CanMove = true;
        IceQueen.GetComponent<IceQueenMainCommand>().DoingAction = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);
        }
    }


    // funcion que determinara que estado tendra
}
