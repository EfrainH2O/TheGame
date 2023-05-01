using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterStun : MonoBehaviour



{   public float TimeToRestart;
    private bool isStun;

    void Start()
    {
        isStun = false;
    }

    // Update is called once per frame

    public void ApplyDamage(float damage)
    {
        Debug.Log("IsDamaged");
        if (!isStun)
        {
            Debug.Log(" IsStuned");
            isStun = true;
            StartCoroutine( Stun( TimeToRestart ) );
        }
    }


    IEnumerator Stun ( float time )
    {
        gameObject.GetComponent<ProjectileAction>().enabled = false;
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<ProjectileAction>().enabled = true;
        isStun = false;

    }
}
