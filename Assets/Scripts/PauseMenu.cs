using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public static bool goingMenu = false;
    public static bool Paused2 = false;
    public static bool goingMenu2 = false;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(Paused) {
                Play();
            } else {
                Stop();
            }
        }
    }

    void Stop() {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        goingMenu = false;

        Paused2 = true;
        goingMenu2 = false;
    }

    public void Play() {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        goingMenu = false;

        // Paused2 = false;
        goingMenu2 = false;
    }

    public void MainMenuButton() {
        // Cursor.lockState = CursorLockMode.None;
		// Cursor.visible = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        goingMenu = true;
        Paused = false;

        Paused2 = false;
        goingMenu2 = true;
    }
}
