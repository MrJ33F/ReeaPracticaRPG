using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        Debug.Log("Hp " + currentHealth);
        animator.SetTrigger("Player_Hit");
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        Debug.Log("Ded");
        animator.SetBool("isDead", true);

        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
    
    }
}
