using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class playerStats : ScriptableObject
{
    // Start is called before the first frame update
    public float health = 100;
    public int damage = 10;

    public Vector2 playerLocation;

    public Vector2 playerLastLocation;

    public bool playerSpoted;
}
