using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    public static void SavePlayer(Player player, int slot)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/" + slot + "player.save";

        PlayerDates data = new(player);

        using FileStream stream = new(path, FileMode.Create);
        try
        {
            formatter.Serialize(stream, data);
            Debug.Log("ok");
            Debug.Log(player.pos[0]);
            Debug.Log(player.pos[1]);
            Debug.Log(player.scene);
            Debug.Log("saveOk");
        }
        finally
        {
            stream.Close();
        }
    }

    public static PlayerDates Load(int slot)
    {
        string path = Application.persistentDataPath + "/" + slot + "player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            using FileStream stream = new(path, FileMode.Open);
            try
            {
                PlayerDates data = formatter.Deserialize(stream) as PlayerDates;
                Debug.Log("Load");
                Debug.Log(data.pos[0]);
                Debug.Log(data.pos[1]);
                GameObject.Find("Player Sprite").transform.position = new Vector2(data.pos[0], data.pos[1]);
                return data;
            }
            finally
            {
                stream.Close();
            }
        }
        else
        {
            return null;
        }
    }

}
