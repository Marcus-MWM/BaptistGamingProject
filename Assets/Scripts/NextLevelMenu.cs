using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevelMenu : MonoBehaviour
{
  //loads game scene
  public void Play() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  //Quits Game
  public void Quit() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Application.Quit();
        Debug.Log("Player has quit the game");
  }
}
