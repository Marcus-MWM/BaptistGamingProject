using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class FloorUncomplete : MonoBehaviour
{
    public GameObject fadeWarning;
    public GameObject uncompletePanel;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other){
        uncompletePanel.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(UncompletedFloor());
        // thePlayer.GetComponent<FirstPersonController>().enabled = false;
        // this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }


    IEnumerator UncompletedFloor(){
        // fadeWarning.SetActive(true);
        yield return new WaitForSeconds(3);
        uncompletePanel.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
