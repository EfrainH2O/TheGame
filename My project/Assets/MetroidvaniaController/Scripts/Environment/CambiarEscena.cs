using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    GameObject mGameObject;
    Collider2D mCollider2D; 

    public bool cambiarEscena = false;
    public int indiceEscena;

    // Start is called before the first frame update
    void Start()
    {
        /* Debug.Log("Start");
        Debug.Log(cambiarEscena);
        Debug.Log("-------------"); */
        mGameObject = GameObject.Find ("Hexagon Pointed-Top");
        mCollider2D = mGameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Debug.Log("Update");
        Debug.Log(cambiarEscena);
        Debug.Log(mGameObject);
        Debug.Log(mCollider2D); */

        /* Debug.Log(cambiarEscena);
        Debug.Log(mCollider2D); */
        if(cambiarEscena) {
            CambiarA(indiceEscena);
            cambiarEscena = false;
            }

    }

    public void CambiarA(int indice){
        SceneManager.LoadScene(indice);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        cambiarEscena = true;
    }

    
}
