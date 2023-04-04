using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControls : MonoBehaviour
{

    public bool swordActive = false;
    public bool gunActive = false;
    public GameObject pickUpDisplay;
    public GameObject realSword;
    public GameObject pistolImage;
    public GameObject realGun;
    public bool hasGun = false;
    
    void Update()
    {

        if(hasGun == true){
            
        }
        if(swordActive == false){
            if(Input.GetButtonDown("Switch")){
                Debug.Log("Switch Weapon");
                swordActive = true;
                gunActive = false;
                realSword.SetActive(true);
                realGun.SetActive(false);
                // pickUpDisplay.SetActive(false);
                // pickUpDisplay.GetComponent<Text>().text = "SWORD";
                // pickUpDisplay.SetActive(true);
                pickUpDisplay.SetActive(false);
                pickUpDisplay.GetComponent<Text>().text = "SWORD";
                pickUpDisplay.SetActive(true);
                pistolImage.SetActive(false);
            }
        }
        if(gunActive == false){
            if(Input.GetButtonDown("Switch2")){
                Debug.Log("Switch Weapon2");
                swordActive = false;
                gunActive = true;
                realGun.SetActive(true);
                realSword.SetActive(false);

                pickUpDisplay.SetActive(false);
                pickUpDisplay.GetComponent<Text>().text = "HANDGUN";
                pickUpDisplay.SetActive(true);
                pistolImage.SetActive(true);
                
            }
        }

    }
}
