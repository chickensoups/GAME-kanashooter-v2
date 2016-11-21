using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerDataUtils
{

    public static PlayerData playerData = new PlayerData();

    public static void saveFirst()
    {
        
    }
    public static void saveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");
        playerData.currentLevelIndex = LevelUtils.currentLevel.GetIndex();

        bf.Serialize(file, playerData);
        file.Close();
    }

    public static PlayerData loadData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat");

            playerData = (PlayerData) bf.Deserialize(file);
            file.Close();
            return playerData;
        }
        return null;
    }
}
