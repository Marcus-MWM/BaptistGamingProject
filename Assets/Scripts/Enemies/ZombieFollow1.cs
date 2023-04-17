using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow1 : MonoBehaviour
{
    
    public GameObject thePlayer;
    public float TargetDistance;
    public float AllowRange = 20;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;

    public float fireRate = 1f;
    public bool isFiring = false;

    public int IsAttacking;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    public float startPosition;
    void Start()
    {
        // startPosition = transform.position;
        // Debug.Log(startPosition + " at!");
        // if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
        //     // Debug.Log(Shot.transform.name + " EnemySee!");
        //     startPosition = Shot.distance;
        //     Debug.Log(startPosition + " at!");
            
        // }
    }

    void Update() {
        TheEnemy.transform.LookAt(thePlayer.transform);

        Vector3 direction = thePlayer.transform.position - transform.position;
        direction.y = 0f; // Set Y component to 0 to prevent looking up

        // Rotate the object towards the player
        TheEnemy.transform.rotation = Quaternion.LookRotation(direction);
        if(PauseMenu.Paused == false){
            if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                // Debug.Log(Shot.transform.name + " EnemySee!");
                TargetDistance = Shot.distance;
                if(TargetDistance < AllowRange && (Shot.transform.name == "EnemyTrigger" || Shot.transform.name == "Capsule")){
                    if(TargetDistance < 1.7){
                        AttackTrigger = 1;
                    } else {
                        AttackTrigger = 0;
                    }
                    EnemySpeed = 0.1f;
                    if (AttackTrigger == 0) {
                        TheEnemy.GetComponent<Animator>().Play("Male_Sword_Walk");
                        TheEnemy.transform.position = Vector3.MoveTowards(TheEnemy.transform.position, thePlayer.transform.position, EnemySpeed);
                    }
                }
                else {
                    EnemySpeed = 0;
                    TheEnemy.GetComponent<Animator>().Play("Male Sword Stance");
                }
            }

            if(AttackTrigger == 1 && isFiring == false){
                EnemySpeed = 0;
                StartCoroutine(EnemyFire());
                
            }
            if(AttackTrigger == 1){
                EnemySpeed = 0;  
            }
        }
    }

    void OnTriggerEnter() {
        AttackTrigger = 1;
    }

    void OnTriggerExit() {
        AttackTrigger = 0;
    }

    IEnumerator EnemyFire(){
        isFiring = true;
        EnemySpeed = 0;
        TheEnemy.GetComponent<Animator>().Play("Male Attack 1", -1, 0);
        TheEnemy.GetComponent<Animator>().Play("Male Attack 1");
        // fireSound.Play();
        // lookingAtPlayer = true;
        GlobalHealth.healthValue -= 5;
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hurtFlash.SetActive(false);
        // genHurt = Random.Ranger(0, 3);
        // hurtSound[genHurt].Play();
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
