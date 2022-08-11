using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenzor : MonoBehaviour
{
    public float checkRadius;
    public LayerMask Player;

    public GameObject Idle;
    public GameObject Action;

    private bool isInChaseRange;
    void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, Player);
        Idle.transform.position = Action.transform.position;
    }

    private void FixedUpdate() {
        if(isInChaseRange){
            Idle.SetActive(false);
            Action.SetActive(true);
        }
        else{
            Idle.SetActive(true);
            Action.SetActive(false);
        }
    }
}
