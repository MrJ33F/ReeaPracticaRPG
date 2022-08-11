using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float[] pos = new float[2];
    public string scene;

    private void Update()
    {
        pos[0] = GameObject.Find("Player Sprite").transform.position.x;
        pos[1] = GameObject.Find("Player Sprite").transform.position.y;
        scene = GameObject.Find("Player Sprite").scene.name;
        Debug.Log("updated");
    }

    public void SavePlayer()
    {
        Debug.Log("saveOk");
    }

    public void SavePlayerConfirmed(int slot)
    {
        pos[0] = GameObject.Find("Player Sprite").transform.position.x;
        pos[1] = GameObject.Find("Player Sprite").transform.position.y;
        scene = GameObject.Find("Player Sprite").scene.name;
        Save.SavePlayer(this,slot);
    }

    public void LoadPlayer(int slot)
    {
        PlayerDates data = Save.Load(slot);
        pos = data.pos;
        scene = data.scene;
    }
}
