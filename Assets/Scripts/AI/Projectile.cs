using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : PoolableObject
{
    public float AutoDestroyTime = 5f;
    public float MoveSpeed = 2f;
    public int Damage = 5;
    public Rigidbody2D rigidbody2D;

    protected Transform Target;
    protected const string DISABLE_METHOD_NAME = "Disable";

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    protected virtual void OnEnable()
    {
        CancelInvoke(DISABLE_METHOD_NAME);
        Invoke(DISABLE_METHOD_NAME, AutoDestroyTime);
    }

    public virtual void Spawn(Vector2 Forward, int Damage, Transform Target)
    {
        this.Damage = Damage;
        this.Target = Target;
        rigidbody2D.AddForce(Forward * MoveSpeed, ForceMode2D.Force);
    }

    public virtual void OnTriggerEnter(Collider2D collider)
    {
        IDamageable damageable;

        if(collider.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(Damage);
        }
        Disable();
    }
    protected void Disable()
    {
        CancelInvoke(DISABLE_METHOD_NAME);
        rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}