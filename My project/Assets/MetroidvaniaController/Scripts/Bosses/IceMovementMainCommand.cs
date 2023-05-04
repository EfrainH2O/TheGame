using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMovementMainCommand : MonoBehaviour
{
    private int life = 6;
    private Vector3 Spawnpoint;
    private Animator animator;
    private bool facingRight;


    public GameObject Player;

    public float TimeInIdle;
    public float speed;
    private bool OnLongRange;
    private bool OnShortRange;
    private bool CanDVD;


    private bool ReadyDecision;
    private int Decision;
    private bool par;





    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        Spawnpoint = transform.position;
        ReadyDecision = false;
        facingRight = false;

    }

    // Update is called once per frame
    void Update()
    {



        if (!ReadyDecision)
        {
            Decision = Random.Range(1, 5);
            if (Decision % 2 == 0 ) {
                par = true;
            }

        }

        if (ReadyDecision)
        {

            if (life >= 5)
            {
                Fase1();
            }
            else if (life >= 3)
            {
                Fase2();
            }
            else if (life >= 1)
            {
                Fase3();
            }
            if (life <= 0)
            {
                Dead();
            }
            StartCoroutine(WaitToEnd(TimeInIdle));
        }
    }





    
    void Flipo()
    {
        if (Player.transform.position.x < transform.position.x && facingRight)  // player izquierda, enemigo derecha
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = false;
        }

        if (Player.transform.position.x > transform.position.x && !facingRight)  // player izquierda, enemigo derecha
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = true;
        }
        
    }



    void MeleeAttack()
    {
        
        transform.GetComponent<Animator>().SetBool("Attack", true);
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Player")
            {
                collidersEnemies[i].gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);
            }
        }
    
    }


    IEnumerator WaitToEnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReadyDecision = false;
    }
}
