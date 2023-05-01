using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public CharacterController2D mCharacterController2D;
    SpriteRenderer m_SpriteRenderer;

    public int HP;

    public void Start()
    {
        gameObject.SetActive(true);

    }

    public void Update() {
        

        if (mCharacterController2D.CanReapear)
        {
           
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.gameObject.tag == "Player")
		{
           if (mCharacterController2D.life < mCharacterController2D.Maxlife){
            mCharacterController2D.HealDamage(HP);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;


                //gameObject.SetActive(false);
            }
		}
       
    }
    
    

   

}
