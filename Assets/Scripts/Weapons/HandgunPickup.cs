using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun;
    public GameObject fakeHandgun;
    public AudioSource handgunPickupSound;
    public GameObject pickUpDisplay;
    public GameObject pistolImage;
    public static bool hasGun = false;

    void OnTriggerEnter(Collider other){
        realHandgun.SetActive(true);
        fakeHandgun.SetActive(false);
        // handgunPickupSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "HANDGUN";
        pickUpDisplay.SetActive(true);
        pistolImage.SetActive(true);
        hasGun = true;
    }
}
