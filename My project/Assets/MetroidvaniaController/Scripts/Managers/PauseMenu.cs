using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
  public GameObject pauseMenu;
  bool isPaused;
  
    void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false; 
    }

    void Update()
    {
        Pause();
    }

    public void Pause()
    {
      if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
      {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
      }
      else if((Input.GetKeyDown(KeyCode.Escape) && isPaused))
      {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false; 
      }
    }
    public void BackTMM()
    {
        SceneManager.LoadScene(0);
    }
}