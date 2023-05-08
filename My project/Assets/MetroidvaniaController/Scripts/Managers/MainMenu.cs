using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
  public GameObject mainMenu;
  
    void Awake()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(true);
    }

    void Update(){}


    public void StartGame()
    {
      Debug.Log("el boton jala");
	   SceneManager.LoadScene(1);
      Debug.Log("ya cambio escena");
    }

   public void Settings()
    {
      Debug.Log("el boton jala");
	   SceneManager.LoadScene(0);
      Debug.Log("ya cambio escena");
    }
}