using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Vector3 Axis;
    private Vector3 Corner;
    public float angle;
    public float speedOfChange;


 



    // Start is called before the first frame update
    void Start()
    {
   
        angle = angle * 1000f;
    
    }

    // Update is called once per frame
    void Update()
    {

        

     
            Axis = transform.position;
            Corner = Vector3.back;
            transform.RotateAround(Axis, Corner, angle );
            


        

    }
    

    




}
