using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject mGameObject;
    Collider2D mCollider2D; 

    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        //mGameObject = GameObject.Find ("Llave");
        mCollider2D = mGameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update(){}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            hasKey = true;
        }
    }
}
