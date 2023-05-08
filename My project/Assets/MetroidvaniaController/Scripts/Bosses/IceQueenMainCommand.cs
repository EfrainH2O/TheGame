using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceQueenMainCommand : MonoBehaviour
{
    private int life = 6;
    private Vector3 Spawnpoint;
    private Animator animator;
    private bool facingRight;


    public GameObject Player;
    public GameObject Entrance;
    private GameObject Canon;
    private GameObject ACanon;
    private GameObject TargetDetection;
    private Transform attackCheck;
    public GameObject DVD;
    

    public float TimeInIdle;
    public float TimeInSingleShoot;
    public float TimeInCentripetalShoot;

    [SerializeField] private float m_DashForce = 25f;
    public float speed;
   

    private bool OnShortRange;
    private bool CanDVD;
    private bool CanMove;
    private bool TargetLook;


    private bool ReadyDecision;
    private int Decision;
    private bool DoingAction;
    private bool par;
    private bool characterOnScene;




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
        TargetDetection = transform.GetChild(2).gameObject;

        attackCheck = transform.Find("AttackCheck").transform;

        Canon.SetActive(false);
        ACanon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        characterOnScene = Entrance.GetComponent<Entry>().HasArrived;
        if (characterOnScene)
        {
            DVDAttack();

            if (!DoingAction)
            {
                Flipo();
            }

            if (!ReadyDecision)
            {
                Decision = Random.Range(1, 5);
                if (Decision % 2 == 0)
                {
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
                    StartCoroutine(Dead());
                }

            }
            Move(CanMove);
            OnShortRange = TargetDetection.GetComponent<Detector>().detected;
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

    IEnumerator MeleeAttack()
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
        DoingAction = true;

    }


    IEnumerator SingleBall(float delay, int Fase)
    {
        DoingAction = true;
        CanMove = false;
        // Animation.setBool ( SingleBall, true )
        ACanon.SetActive(true);
        yield return new WaitForSeconds(delay);
        ACanon.SetActive(false);
        // Animation.setBool ( SingleBall, false )
        if (Fase == 3)
        {
            CanMove = true;
        }
        DoingAction = false;
        StartCoroutine(WaitToEnd(TimeInIdle));
        
    }

    IEnumerator CentripetalBalls(float delay, int Fase)
    {
        DoingAction = true;
        CanMove = false;
        // Animation.setBool ( CentripetalBalll, true )
        Canon.SetActive(true);
        yield return new WaitForSeconds(delay);
        Canon.SetActive(false);
        // Animation.setBool ( CentripetalBall, false )
        if (Fase  == 3)
        {
            CanMove = true;
        }
        DoingAction = false;
        StartCoroutine(WaitToEnd(TimeInIdle));

    }

    void Slash()
    {
        DoingAction = true;
        CanMove = false;
        MeleeAttack();
        StartCoroutine(WaitToEnd(TimeInIdle));

    }

    void Dash()
    {
        transform.Translate (new Vector3(transform.localScale.x * m_DashForce, 0, 0));
        //Animator true
        StartCoroutine(WaitToEnd(TimeInIdle));
    }


    void DVDAttack()
    {
        if (CanDVD)
        {
            CanDVD = false;
            GameObject TheDVD = Instantiate(DVD, Spawnpoint, Quaternion.identity) as GameObject;
            TheDVD.name = "DVD";
            StartCoroutine(DVDDelay());
        }
    }

    void Move (bool can)
    {
        if (can && !TargetLook)
        {
            TargetLook = true;
            transform.position =  Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            StartCoroutine(LockingTarget());
        }
    }

    void Respawn()
    {
        if (Player.GetComponent<CharacterController2D>().CanReapear)
        {
            transform.position = Spawnpoint;
            life = 6;

            //Animator.setBool ( "cada uno que falte", false);
        }
    }


    IEnumerator WaitToEnd(float delay)
    {
        Flipo();
        yield return new WaitForSeconds(delay);
        ReadyDecision = false;
    }

    IEnumerator LockingTarget()
    {
        Flipo();
        yield return new WaitForSeconds(0.5f);
        TargetLook = false;
    }

    IEnumerator DVDDelay()
    {
        yield return new WaitForSeconds(30f);
        CanDVD = true;
    }

    void Fase1()
    {
        if (par)
        {
            CentripetalBalls(TimeInCentripetalShoot, 1);
        }
        else
        {
            SingleBall(TimeInSingleShoot, 2);
        }
    }
    void Fase2()
    {
        if (par)
        {
            Slash();
        }
        else
        {
            Dash();
        }
    }
    void Fase3()
    {
        //Animator fase3 true;
        if(Decision == 1 && OnShortRange )
        {
            Slash(); 
        }
        else if (Decision == 2 && OnShortRange)
        {
            Dash(); 
        }
        else if (Decision == 3)
        {
            SingleBall(TimeInSingleShoot, 3);
        }
        else if (Decision == 4)
        {
            CentripetalBalls(TimeInCentripetalShoot, 3);
        }
    }

    IEnumerator Dead()
    {
        //animator dead true
        CanDVD = false;
        CanMove = false;
        Canon.SetActive(false);
        ACanon.SetActive(false);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(transform.position);
        }
        else if (collision.gameObject.tag == "DVD" && collision.gameObject.GetComponent<RetournDamage>().isHit)
        {
            life = life-1;
            Destroy(collision.gameObject);
        }
    }

   
   



}
    
