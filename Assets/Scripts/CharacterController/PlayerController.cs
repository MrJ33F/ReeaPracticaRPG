using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed;
    private Animator _animator;
    private PlayerControls _playerControls;
    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;
    private SpriteRenderer _spriteRenderer;

    private bool direction = false; //false x = -1 true y = +1

    private void Awake()
    {
        _playerControls = new PlayerControls();

        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _animator?.SetBool("Player_Idle", true);

        if (_rigidBody is null)
            Debug.LogError("RigidBody2D NULL!");
        if (_animator is null)
            Debug.LogError("Animator is NULL!");
        if (_spriteRenderer is null)
            Debug.LogError("Animator is NULL!");
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void FixedUpdate()
    {
        _movementInput = _playerControls.Player_Controls.Movement.ReadValue<Vector2>();

        _animator.transform.localRotation = (_movementInput.x >= 0) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
        transform.localRotation = (_movementInput.x >= 0) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);

        _animator.SetBool("moving", _playerControls.Player_Controls.Movement.IsPressed());
        _animator.SetBool("isAttackingCombo",
                         (_animator.GetBool("moving") &&
                         _playerControls.Player_Controls.Attack.IsPressed()) || (_playerControls.Player_Controls.Attack.IsPressed()));
        _animator.SetBool("isRolling", (_animator.GetBool("moving") &&
                                        (_playerControls.Player_Controls.Roll.IsPressed())));
        _animator.SetBool("isDashing", (_animator.GetBool("moving") &&
                                        (_playerControls.Player_Controls.Dash.IsPressed())));

        _rigidBody.velocity = _movementInput * playerSpeed;
    }
    

}
