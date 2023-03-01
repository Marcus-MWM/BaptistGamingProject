using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FloorComplete : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject completePanel;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other){
        StartCoroutine(CompletedFloor());
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator CompletedFloor(){
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        completePanel.SetActive(true);
    }
}
