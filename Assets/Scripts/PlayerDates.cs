using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDates : MonoBehaviour
{
    private float[] pos= new float[2];
    private string scene;

    // Update is called once per frame
    void Update()
    {
        pos[0] = GameObject.Find("Player Sprite").transform.position.x;
        pos[1] = GameObject.Find("Player Sprite").transform.position.y;
        scene = GameObject.Find("Player Sprite").scene.name;
    }
}
