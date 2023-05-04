using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
  public GameObject mainMenu;
  public GameObject settings;
  bool isPaused;

    void Awake()
    {
    	Time.timeScale = 0;
        mainMenu.SetActive(true);
        settings.SetActive(false);

    }

    void Update()
    {

    }

    public void StartGame()
    {
       mainMenu.SetActive(false);
       SceneManager.LoadScene(1);
    }

    public void Settings()
    {
       mainMenu.SetActive(false);
       settings.SetActive(true);
    }

    public void BackToMM()
    {
       mainMenu.SetActive(true);
       settings.SetActive(false);
    }

}