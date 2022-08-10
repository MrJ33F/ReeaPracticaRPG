using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackRadius : MonoBehaviour
{
    public SphereCollider Collider;
    protected List<IDamageable> Damageables = new List<IDamageable>();
    public delegate void AttackEvent(IDamageable Target);

    public int Damage = 10;
    public float AttackDelay = 0.5f;
    public AttackEvent OnAttack;
    protected Coroutine AttackCoroutine;

    protected virtual void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            Damageables.Add(damageable);

            if (AttackCoroutine == null) AttackCoroutine = StartCoroutine(Attack());
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            Damageables.Remove(damageable);

            if(Damageables.Count == 0)
            {
                StopCoroutine(AttackCoroutine);
                AttackCoroutine = null;
            }
        }
    }

    protected virtual IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(AttackDelay);

        yield return Wait;

        IDamageable closestDamageable = null;
        float closestDistance = float.MaxValue;

        while(Damageables.Count > 0)
        {
            for(int index = 0; index < Damageables.Count; index++)
            {
                Transform damageableTransform = Damageables[index].GetTransform();
                float distance = Vector3.Distance(transform.position, damageableTransform.position);

                if(distance < closestDistance)
                {
                    closestDistance = distance;
                    closestDamageable = Damageables[index];
                }
            }

            if (closestDamageable != null)
            {
                OnAttack?.Invoke(closestDamageable);
                closestDamageable.TakeDamage(Damage);
            }

            closestDamageable = null;
            closestDistance = float.MaxValue;

            yield return Wait;
            Damageables.RemoveAll(DisabledDamageables);
        }
    }

    protected bool DisabledDamageables(IDamageable damageable)
    {
        return damageable != null && !damageable.GetTransform().gameObject.activeSelf;
      
    }
}
