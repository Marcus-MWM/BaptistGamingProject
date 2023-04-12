using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public Transform thePlayer;
    public RaycastHit Shot;
    public float TargetDistance;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public GameObject thePlayer2;
    void Update()
    {
        transform.LookAt(thePlayer);


        Vector3 direction = thePlayer2.transform.position - transform.position;
        direction.y = 0f; // Set Y component to 0 to prevent looking up

        // Rotate the object towards the player
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
