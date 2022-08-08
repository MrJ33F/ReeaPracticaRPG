using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public GameObject player;
    public VectorValue initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = Instantiate(player) as GameObject;
        p.transform.position = initialPosition.initialValue;
    }

}
