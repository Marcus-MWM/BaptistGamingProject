using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHealth = 20;
    public bool enemyDead = false;
    public GameObject enemyAI;
    public GameObject theEnemy;
    public GameObject bodyEnemy;
    public GameObject healthBox;
    
    void DamageEnemy(int damageAmount){
        enemyHealth -= damageAmount;
    }

    void Update()
    {
        if(enemyHealth <= 0 && enemyDead == false){
            int precentHealth = Random.Range(1,11);
            enemyDead = true;
            theEnemy.GetComponent<Animator>().Play("Death");
            Debug.Log ("DEAD YAY!");
            enemyAI.SetActive(false);
            theEnemy.GetComponent<LookPlayer>().enabled = false;
            bodyEnemy.GetComponent<BoxCollider>().enabled = false;
            GlobalScore.scoreValue += 100;
            GlobalComplete.enemyCount += 1;
            Debug.Log(precentHealth + " is this precent!");
            if(precentHealth > 5){
                Debug.Log("Has health box");
                healthBox.SetActive(true);
            }
            
        }
        
    }
}
