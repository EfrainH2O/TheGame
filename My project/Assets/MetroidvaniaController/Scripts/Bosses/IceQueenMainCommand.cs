using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceQueenMainCommand: MonoBehaviour
{
    private int life = 6;
    private Vector3 Spawnpoint;
    private Animator animator;
    private bool facingRight;


    public GameObject Player;
    private GameObject Canon;
    private GameObject ACanon;
    private GameObject attackCheck;

    public float TimeInIdle;
    public float TimeInSingleShoot;
    public float TimeInCentripetalShoot;


    public float speed;
    public float distance;
   
    private bool OnShortRange;
    private bool CanDVD;


    private bool ReadyDecision;
    private int  Decision;
    private bool par;
    private bool CanMove;




    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        Spawnpoint = transform.position;
        ReadyDecision = false;
        facingRight = false;
        CanMove = false;
        Canon = transform.GetChild(0).gameObject;
        ACanon = transform.GetChild(1).gameObject;

        Canon.SetActive(false);
        ACanon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Flipo();

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
            else if (life <= 0)
            {
                Dead();
            }
            
        }
        Respawn();
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

    public IEnumerator MeleeAttack ()
    {

        transform.GetComponent<Animator>().SetBool("Slash", true);
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Player")
            {
                collidersEnemies[i].gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);
            }
        }
        yield return new WaitForSeconds(1.3f);
        CanMove = true;

    }


    IEnumerator WaitToEnd(float delay)
    {
        Flipo();
        yield return new WaitForSeconds(delay);
        ReadyDecision = false;
    }


    IEnumerator SingleBall(float delay)
    {   
        CanMove = false;
        // Animation.setBool ( SingleBall, true )
        ACanon.SetActive(true);
        yield return new WaitForSeconds(delay);
        ACanon.SetActive(false);
        // Animation.setBool ( SingleBall, false )
        CanMove = true;

        StartCoroutine(WaitToEnd(TimeInIdle));

    }

    IEnumerator CentripetalBalls(float delay)
    {

        CanMove = false;
        // Animation.setBool ( CentripetalBalll, true )
        Canon.SetActive(true);
        yield return new WaitForSeconds(delay);
        Canon.SetActive(false);
        // Animation.setBool ( CentripetalBall, false )
        CanMove = true;

        StartCoroutine(WaitToEnd(TimeInIdle));
        
    }

    void Slash ()
    {
        CanMove = false;
        MeleeAttack();
        StartCoroutine(WaitToEnd(TimeInIdle));

    }

    IEnumerator Dash()
    {

    }

    void Move( bool can, float speed )
    {
        if (can)
        {

        }
        else
        {

        }
    }

    void Respawn()
    {
        if (Player.GetComponent<CharacterController2D>().CanReapear)
        {
            transform.position = Spawnpoint;
            life = 6;
            //Animator.setBool (cadaUno, false);
        }
    }


}
