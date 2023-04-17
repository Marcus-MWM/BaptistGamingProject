using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath1 : MonoBehaviour
{
    public int enemyHealth = 20;
    public bool enemyDead = false;
    public GameObject enemyAI;
    public GameObject theEnemy;
    public GameObject bodyEnemy;
    public GameObject healthBox;
    public GameObject ammoBox;
    public GameObject hurtFlash;
    
    void DamageEnemy(int damageAmount){
        enemyHealth -= damageAmount;
    }

    void Update()
    {
        if(enemyHealth <= 0 && enemyDead == false){
            int precentHealth = Random.Range(1,11);
            int precentAmmo = Random.Range(1, 11);
            enemyDead = true;
            bodyEnemy.GetComponent<BoxCollider>().enabled = false;
            theEnemy.GetComponent<Animator>().Play("Male Die");
            Debug.Log ("DEAD YAY!");
            enemyAI.SetActive(false);
            theEnemy.GetComponent<LookPlayer>().enabled = false;
            bodyEnemy.GetComponent<BoxCollider>().enabled = false;
            GlobalScore.scoreValue += 100;
            GlobalComplete.enemyCount += 1;
            Debug.Log(precentHealth + " is this precent!");
            if(precentHealth > 3){
                Debug.Log("Has health box");
                healthBox.SetActive(true);
            }
            if(precentAmmo > 5){
                Debug.Log("Has ammo box");
                ammoBox.SetActive(true);
            }
            if (hurtFlash.activeSelf)
            {
                hurtFlash.SetActive(false);
            }
        }
        
    }
}
