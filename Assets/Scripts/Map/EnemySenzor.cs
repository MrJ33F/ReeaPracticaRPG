using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenzor : MonoBehaviour
{
    public playerStats statsPlayer;
    public VectorValue playerLocation;
    public float checkRadius;
    public float checkRadiusExit;
    public LayerMask Player;

    public GameObject Idle;
    public GameObject Action;

    private bool isInChaseRange;
    private bool IsExitChaseRange;
    void Update()
    {
        transform.position = Idle.transform.position;

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, Player);
        IsExitChaseRange = Physics2D.OverlapCircle(transform.position, checkRadiusExit, Player);
        if(!statsPlayer.playerSpoted){
        Idle.transform.position = Action.transform.position;}
        
    }

    private void FixedUpdate() {
        if(isInChaseRange){
            Idle.SetActive(false);
            Action.SetActive(true);
            
            if (IsExitChaseRange){
                statsPlayer.playerLastLocation = playerLocation.playerLocation;
                statsPlayer.playerSpoted = true;
                Debug.Log("work");
            }
        }
        else{
            
            
        
            Idle.SetActive(true);
            Action.SetActive(false);
        }
    }
    

    
}
