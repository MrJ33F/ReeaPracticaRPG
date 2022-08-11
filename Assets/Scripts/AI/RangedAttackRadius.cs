using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RangedAttackRadius : AttackRadius
{
    public NavMeshAgent Agent;
    public Projectile ProjectilePrefab;
    public Vector3 ProjectileSpawnOffset = new Vector3(0, 1, 0);
    public LayerMask Mask;

    private ObjectPool ProjectilePool;
    [SerializeField] private float SphereRadius = 0.1f;
    private RaycastHit Hit;
    private IDamageable targetDamageable;
    private Projectile projectile;

    public void CreateProjectilePool()
    {
        if (ProjectilePool == null)
        {
            ProjectilePool = ObjectPool.CreateInstance(ProjectilePrefab, Mathf.CeilToInt((1 / AttackDelay) * ProjectilePrefab.AutoDestroyTime));
        }
    }

    protected override IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(AttackDelay);

        yield return Wait;

        while (Damageables.Count > 0)
        {
            for (int index = 0; index < Damageables.Count; index++)
            {
                if (HasLineOfSightTo(Damageables[index].GetTransform()))
                {
                    targetDamageable = Damageables[index];
                    OnAttack?.Invoke(Damageables[index]);
                    Agent.enabled = false;
                    break;
                }
            }

            if(targetDamageable != null)
            {
                PoolableObject poolableObject = ProjectilePool.GetObject();
                if(poolableObject != null)
                {
                    projectile = poolableObject.GetComponent<Projectile>();

                    projectile.transform.position = transform.position + ProjectileSpawnOffset;
                    projectile.transform.rotation = Agent.transform.rotation;

                    projectile.Spawn(Agent.transform.forward, Damage, targetDamageable.GetTransform());
                }
            }
            else
            {
                Agent.enabled = false; // nu exista o tinta in line of sight, incercam sa ne apropiem de aceasta
            }

            yield return Wait;

            if(targetDamageable == null || !HasLineOfSightTo(targetDamageable.GetTransform()))
            {
                Agent.enabled = true;
            }

            Damageables.RemoveAll(DisabledDamageables);
        }

        Agent.enabled = true;
        AttackCoroutine = null;
    }

    private bool HasLineOfSightTo(Transform transform)
    {
        if(Physics.SphereCast(transform.position + ProjectileSpawnOffset, SphereRadius, 
            ((transform.position + ProjectileSpawnOffset) - (transform.position + ProjectileSpawnOffset)).normalized, out Hit, Collider.radius, Mask))
        {
            IDamageable damageable;
            if(Hit.collider.TryGetComponent<IDamageable>(out damageable))
            {
                return damageable.GetTransform() == transform;
            }
        }

        return false;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (AttackCoroutine == null) Agent.enabled = true;
    }
}