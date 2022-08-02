using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/player.save";

        PlayerData data = new(player);

        using FileStream stream = new(path, FileMode.Create);
        try
        {
            formatter.Serialize(stream, data);
        }
        finally
        {
            stream.Close();
        }
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            using FileStream stream = new(path, FileMode.Open);
            try
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
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
