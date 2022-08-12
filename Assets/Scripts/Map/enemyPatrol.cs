using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public playerStats playerLastLocation;
    public GameObject enemyAttakPos;
    public float speed;

    private bool playerSpoted;
    
    
    private void Update() {
        enemyAttakPos.transform.position = transform.position;
        if(playerLastLocation.playerSpoted){
            transform.position = Vector2.MoveTowards(transform.position, playerLastLocation.playerLastLocation, speed * Time.deltaTime);
        }
    }
    
    
}
