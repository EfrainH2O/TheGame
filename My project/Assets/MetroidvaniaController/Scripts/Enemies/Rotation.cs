using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Vector3 Axis;
    private Vector3 Corner;
    public float angle;
    public float speedOfChange;
    private bool can;

 



    // Start is called before the first frame update
    void Start()
    {
        can = true;
        angle = angle * 1000f;
    
    }

    // Update is called once per frame
    void Update()
    {


        if (can)
        {

            can = false;
            Axis = transform.position;
            Corner = Vector3.back;
            transform.RotateAround(Axis, Corner, angle );
            StartCoroutine(Wait(speedOfChange));


        }

    }
    

    


    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        can = true;
    }

}
