using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecycleLevel : MonoBehaviour
{
    public GameObject gameOver;

    void Start()
    {
        GlobalLife.lifeValue -= 1;
        GlobalScore.scoreValue = 0;
        GlobalComplete.enemyCount= 0;
        GlobalComplete.treasureCount = 0;

        if (GlobalLife.lifeValue == 0){
            gameOver.SetActive(true);
        }
        else{
            SceneManager.LoadScene(2);
        }
    }

}
