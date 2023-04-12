using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

  void Start()
    {
      Cursor.lockState = CursorLockMode.None;
		  Cursor.visible = true;
    }

  //loads game scene
  public void Play() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  //Quits Game
  public void Quit() {
        Application.Quit();
        Debug.Log("Player has quit the game");
  }
}
