using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int enemyHealth = 20;
    public bool enemyDead = false;
    public GameObject enemyAI;
    public GameObject theEnemy;
    public GameObject bodyEnemy;
    
    void DamageEnemy(int damageAmount){
        enemyHealth -= damageAmount;
    }

    void Update()
    {
        if(enemyHealth <= 0 && enemyDead == false){
            enemyDead = true;
            theEnemy.GetComponent<Animator>().Play("Death");
            Debug.Log ("DEAD YAY!");
            // enemyAI.SetActive(false);
            // theEnemy.GetComponent<LookPlayer>().enabled = false;
            theEnemy.GetComponent<ZombieFollow>().enabled = false;
            bodyEnemy.GetComponent<BoxCollider>().enabled = false;
            GlobalScore.scoreValue += 100;
            GlobalComplete.enemyCount += 1;
        }
        
    }
}
