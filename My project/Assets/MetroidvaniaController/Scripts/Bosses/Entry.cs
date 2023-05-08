using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    // Start is called before the first frame update
    public bool HasArrived;
    private GameObject Player;

    public void OnCollisionExit2D (collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            HasArrived = true;
        }
    }

    void Start()
    {
        Player = GameObject.Find("DrawnCharacter");
        HasArrived = false;
    }


    void Update()
    {
        if (Player.GetComponent<CharacterController2D>().CanReapear)
        {
            HasArrived = false;
        }
    }
}
