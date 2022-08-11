using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed;

    private Rigidbody2D rigidBody;
    private PlayerControls playerControlls;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    public playerStats statsPlayer;


    bool lookingRight = true;
    private Vector2 movement;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    int attackDamage = 5;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerControlls = new PlayerControls();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }

    private void FixedUpdate()
    {
        ProcessMovement();
        ProcessAttack();
        ProcessSpecialMovement();
    }

    private void ProcessMovement()
    {
        movement = playerControlls.Player_Controls.Movement.ReadValue<Vector2>();
        animator.SetBool("moving", (movement.x != 0) || (movement.y != 0));
        rigidBody.velocity = movement * playerSpeed;

        if (movement.x > 0 && !lookingRight) Flip();
        if (movement.x < 0 && lookingRight) Flip();
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        lookingRight = !lookingRight;
    }

    private void ProcessAttack()
    {
        if (playerControlls.Player_Controls.Attack.IsPressed())
        {
            
            bool playerClicked = playerControlls.Player_Controls.Attack.IsPressed();
            animator.SetBool("isAttackingCombo", (animator.GetBool("moving") && playerClicked) || playerClicked);
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in enemiesHit)
            {
                Debug.Log("Hit: " + enemy.name);
                enemy.GetComponent<Entity>().TakeDamage(statsPlayer.damage);
            }
                

                Debug.Log("Hit goblin ");
        }
        else {
            
            animator.SetBool("isAttackingCombo", false);
        }
    }

    private void ProcessSpecialMovement()
    {
        playerControlls.Player_Controls.Roll.performed += Roll;
        playerControlls.Player_Controls.Roll.canceled += RollEnd;

        playerControlls.Player_Controls.Dash.performed += Dash;
        playerControlls.Player_Controls.Dash.canceled += EndDash;
    }

    private void Roll(InputAction.CallbackContext context)
    {
        animator.SetBool("isRolling", true);
        rigidBody.AddForce(new Vector2((movement.x * playerSpeed * 800f), 0f));
    }
    private void RollEnd(InputAction.CallbackContext context)
    {
        animator.SetBool("isRolling", false);
    }

    private void Dash(InputAction.CallbackContext context)
    {
        animator.SetBool("isDashing", true);
        rigidBody.AddForce(new Vector2((movement.x * playerSpeed * 350f), 0f));
    }
    private void EndDash(InputAction.CallbackContext context)
    {
        animator.SetBool("isDashing", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
    