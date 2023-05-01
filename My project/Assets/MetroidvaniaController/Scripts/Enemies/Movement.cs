using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 start;
    public Vector3 superiorEnd;
    public Vector3 inferiorEnd;

    public bool Movementx;
    public bool Movementy;

    private float rate_x;
    private float rate_y;
    
    private float Udifference_x;
    private float Ddifference_x;
    private float Udifference_y;
    private float Ddifference_y;

    private float stepness;
    private float constant;
    public float speed;

    private void Awake() {

        start = transform.position;

        if ( Movementx ){
            rate_x = speed;
        }

        if ( Movementy ){
            rate_y = speed;
        }

        if(Movementy && Movementx){
        stepness = (superiorEnd.y - inferiorEnd.y) / (superiorEnd.x - inferiorEnd.x); 

        constant = superiorEnd.y - (stepness * superiorEnd.x);

        transform.position = new Vector3(transform.position.x, transform.position.y + constant , 0);
        }



        Udifference_x = superiorEnd.x + start.x;
        Ddifference_x = inferiorEnd.x + start.x;
        Udifference_y = superiorEnd.y + start.y;
        Ddifference_y = inferiorEnd.y + start.y;

     


    }

    private void Update() {
        updateRate();
        transform.position = new Vector3(transform.position.x + rate_x, transform.position.y + rate_y , 0);
    }


    private void updateRate(){
        if ( transform.position.x >= Udifference_x ){rate_x = -speed; Debug.Log("going left");}
        else if ( Ddifference_x >= transform.position.x ){rate_x = speed; Debug.Log("going right");}

        if ( transform.position.y >= Udifference_y ) {rate_y = -speed; Debug.Log("going Down");}
        else if ( Ddifference_y >= transform.position.y ){rate_y = speed; Debug.Log("going Up");}

         if ( Movementy && Movementx ){
            rate_y = rate_x * stepness;
        }
    }







}
