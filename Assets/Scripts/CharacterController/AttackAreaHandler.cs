using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaHandler : MonoBehaviour
{

    int attackDamage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() != null)
        {
            Entity entity = collision.GetComponent<Entity>();
            Debug.Log("Ouch :(");
            entity.TakeDamage(attackDamage);
        }
    }
}
