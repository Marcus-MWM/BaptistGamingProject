using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : MonoBehaviour
{
    public float range = 100f;      // Maximum range of the weapon
    public int bulletsPerMag = 30;     //Bullets per each magazine
    public int bulletsLeft = 200;   //Total bullets we have
    public int currentBullets;      //The current bullets in our magazine

    public Transform shootPoint;    //The point from which the bullet leaves the muzzle

    public float fireRate = 0.1f;   //The delay between each shot

    float fireTimer;    //Time counter for the delay

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletsPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            Fire();     // Execute the fure function if we press/hold the left mouse button
        }

        if(fireTimer < fireRate)
            fireTimer += Time.deltaTime;        // Add into time counter
    }

    private void Fire(){
        if(fireTimer < fireRate) return;
        // Debug.Log("Fire-d!");

        RaycastHit hit;

        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name + " found!");
        }

        currentBullets--;
        fireTimer = 0.0f;   //Reset fire timer
    }
}
