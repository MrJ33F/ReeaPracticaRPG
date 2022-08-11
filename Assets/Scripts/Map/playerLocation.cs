using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocation : MonoBehaviour
{
    // Start is called before the first frame update
    public VectorValue playerLoc;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerLoc.playerLocation;
    }
}
