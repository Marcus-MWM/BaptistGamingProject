using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject theSoldier;
    public AudioSource fireSound;
    public bool isFiring = false;
    public float fireRate = 1f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit)){
            hitTag = Hit.transform.tag;
        }
        if(hitTag == "Player" && isFiring == false){
            StartCoroutine(EnemyFire());
        }
        if(hitTag != "Player"){
            theSoldier.GetComponent<Animator>().Play("Idle");
            lookingAtPlayer = false;
        }
    }

    IEnumerator EnemyFire(){
        isFiring = true;
        theSoldier.GetComponent<Animator>().Play("FireShoot", -1, 0);
        theSoldier.GetComponent<Animator>().Play("FireShoot");
        // fireSound.Play();
        lookingAtPlayer = true;
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
