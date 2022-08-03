using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int level = 1;
    public int health = 40;

    public void SavePlayer()
    {
        Debug.Log("saveOk");
    }

    public void SavePlayerConfirmed()
    {
        Debug.Log("saveOk");
        Save.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = Save.Load();
        level = data.level;
        health = data.health;
    }
}
