using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public DataManager Instance;
   
    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }


    private void Start() {
        DontDestroyOnLoad(gameObject);
    }


    public void rRespawn(){

    }
}
