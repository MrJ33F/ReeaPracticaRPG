using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDates
{
    public float[] pos;
    public string scene;

    public PlayerDates(Player player)
    {
        pos = new float[2];
        pos = player.pos;
        scene = player.scene;
    }

}
