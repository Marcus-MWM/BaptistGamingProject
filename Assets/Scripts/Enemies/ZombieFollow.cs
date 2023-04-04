using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    
    public GameObject thePlayer;
    public float TargetDistance;
    public float AllowRange = 10;
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
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
            // Debug.Log(Shot.transform.name + " EnemySee!");
            TargetDistance = Shot.distance;
            if(TargetDistance < AllowRange && (Shot.transform.name == "EnemyTrigger" || Shot.transform.name == "Capsule")){
                EnemySpeed = 0.02f;
                if (AttackTrigger == 0) {
                    TheEnemy.GetComponent<Animator>().Play("Run_guard");
                    TheEnemy.transform.position = Vector3.MoveTowards(TheEnemy.transform.position, thePlayer.transform.position, EnemySpeed);
                }
            }
            else {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animator>().Play("Idle");
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

    void OnTriggerEnter() {
        AttackTrigger = 1;
    }

    void OnTriggerExit() {
        AttackTrigger = 0;
    }

    IEnumerator EnemyFire(){
        isFiring = true;
        EnemySpeed = 0;
        TheEnemy.GetComponent<Animator>().Play("FireShoot", -1, 0);
        TheEnemy.GetComponent<Animator>().Play("FireShoot");
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
