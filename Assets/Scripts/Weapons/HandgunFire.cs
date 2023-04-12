using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject theGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public bool isFiring = false;
    public AudioSource emptySound;
    public float targetDistance;
    public int damageAmount = 5;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(PauseMenu.Paused2 == true){
                StartCoroutine(startUpGame()); 
                PauseMenu.Paused2 = false;
            }
            else if(GlobalAmmo.handgunAmmo < 1){
                // emptySound.Play();
            }
            else {
                if(isFiring == false){
                    StartCoroutine(FiringHandgun());
                }
            }
        }
    }

    IEnumerator startUpGame(){
        yield return new WaitForSeconds(5);
    }

    IEnumerator FiringHandgun(){
        RaycastHit theShot;
        isFiring = true;
        GlobalAmmo.handgunAmmo -= 1;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot)){
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot)){
            Debug.Log(theShot.transform.name + " found!");
        }
        theGun.GetComponent<Animator>().Play("HandgunFire");
        muzzleFlash.SetActive(true);
        // gunFire.Play();
        
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
