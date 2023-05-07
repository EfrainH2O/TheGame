using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    private Vector3 start;
    public Vector3 superiorEnd;
    public Vector3 inferiorEnd;

    private float rate_x;
    private float rate_y;
    
    private float Udifference_x;
    private float Ddifference_x;
    private float Udifference_y;
    private float Ddifference_y;

    public float speed;

    private void Awake() {

        start = transform.position;

       rate_x = speed * Time.fixedDeltaTime;
       rate_y = speed * Time.fixedDeltaTime;

        Udifference_x = superiorEnd.x + start.x;
        Ddifference_x = inferiorEnd.x + start.x;
        Udifference_y = superiorEnd.y + start.y;
        Ddifference_y = inferiorEnd.y + start.y;

     


    }

    private void FixedUpdate() {
        updateRate();
        transform.position = new Vector3(transform.position.x + rate_x, transform.position.y + rate_y , 0);
    }


    private void updateRate(){
        if ( transform.position.x >= Udifference_x ){rate_x = -speed * Time.fixedDeltaTime; Debug.Log("going left");}
        else if ( Ddifference_x >= transform.position.x ){rate_x = speed * Time.fixedDeltaTime; Debug.Log("going right");}
        if ( transform.position.y >= Udifference_y ) {rate_y = -speed * Time.fixedDeltaTime; Debug.Log("going Down");}
        else if ( Ddifference_y >= transform.position.y ){rate_y = speed * Time.fixedDeltaTime; Debug.Log("going Up");}
    }
}