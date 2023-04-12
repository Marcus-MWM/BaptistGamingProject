using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunAmmoPick : MonoBehaviour
{
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other){
        fakeAmmoClip.SetActive(false);
        // ammoPickupSound.Play();
        if(GlobalAmmo.handgunAmmo >= 181){
            GlobalAmmo.handgunAmmo = 200;
        } 
        else{
            GlobalAmmo.handgunAmmo += 20;
        }
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "CLIP OF BULLETS";
        pickUpDisplay.SetActive(true);
    }
}
