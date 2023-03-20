using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{

    public GameObject theSword;
    // public GameObject muzzleFlash;
    public AudioSource swordSlash;
    public bool isAttacking = false;
    // public AudioSource emptySound;
    public float targetDistance;
    public int damageAmount = 10;


    void Update()
    {
        if(Input.GetButtonDown("Fire1")){

            if(isAttacking == false){
                StartCoroutine(useSword());
            }
        }
    }


    IEnumerator useSword(){
        RaycastHit theHit;
        isAttacking = true;
        // GlobalAmmo.handgunAmmo -= 1;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theHit)){
            targetDistance = theHit.distance;
            theHit.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theHit)){
            Debug.Log(theHit.transform.name + " found!");
        }
        theSword.GetComponent<Animator>().Play("HandgunFire");
        // muzzleFlash.SetActive(true);
        // gunFire.Play();
        
        yield return new WaitForSeconds(0.05f);
        // muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        theSword.GetComponent<Animator>().Play("New State");
        isAttacking = false;
    }
}
