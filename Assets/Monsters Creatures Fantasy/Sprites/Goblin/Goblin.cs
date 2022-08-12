using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using Pathfinding;

public class Goblin : MonoBehaviour
{
    public playerStats StatusP;
    public AIPath aiPath;
    public Animator animator;
    
    public LayerMask playerPosition;
    
    public GameObject playerTransform;
    public GameObject playerIdle;
    
    private float idleRadius = 3f;
    private bool isIdleRange;
    private bool isInAttackRange;

    public GameObject attackPoint;
    private float attackRange = 0.5f;

    private float lastAttack;
    public float attackDelay = 0.5f;

    public float attackPct = 5;
    // Update is called once per frame
    private void Start() {
        
    }
    void Update()
    {
        
        playerIdle.transform.position = transform.position;
        isIdleRange = Physics2D.OverlapCircle(transform.position, idleRadius, playerPosition);
        //flip
        if(aiPath.desiredVelocity.x >= 0.01f){
            
            transform.localScale = new Vector3 (1.2828f,1.2828f,1.2828f);
        }
        else if(aiPath.desiredVelocity.x >= -0.01f){
            
            transform.localScale = new Vector3 (-1.2828f,1.2828f,1.2828f);
        }
        //attack
            isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, playerPosition);
            if(isInAttackRange){
               animator.SetBool("isRuning", false);
               animator.SetBool("Attack", true); 
               Attack(); 
            }
            else{
                animator.SetBool("isRuning", true);
                animator.SetBool("Attack", false); 
            }
        
        //anim
        if(!isIdleRange){
            animator.SetBool("isRuning", true);
            animator.SetBool("Attack", false);
        }

        
    }
    

    void Attack(){
        

        
        float distanceToPlayer = Vector2.Distance(attackPoint.transform.position, playerTransform.transform.position);

        if(distanceToPlayer < attackRange){
            if(Time.time > lastAttack + attackDelay)
            {
            Debug.Log("Hit");
            StatusP.health -= 5;
            lastAttack = Time.time;
            }
            
            
        }
        



    }
    void takeDamage(){

    }
    void OnDrawGizmosSelected() {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
