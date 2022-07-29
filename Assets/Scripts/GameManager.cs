using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //public static SaveData coinData;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
            Destroy(gameObject);
        //InitailizeGameData();
    }
    //private void Start()
    //{
    //    Debug.Log(Application.persistentDataPath + "/coin.dat");
    //}

    //void InitailizeGameData()
    //{
    //    LoadCoin();
    //    if (coinData == null)
    //    {
    //        coinData.coin = 0;
    //        SaveCoin();
    //    }
    //}

    //public static void SaveCoin()
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/coin.dat";

    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    //SaveData coinData = new SaveData();

    //    formatter.Serialize(stream, coinData);
    //    stream.Close();

    //}

    //public static SaveData LoadCoin()
    //{
    //    string path = Application.persistentDataPath + "/coin.fit";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        coinData = formatter.Deserialize(stream) as SaveData;
    //        stream.Close();
    //        return coinData;
    //    }
    //    else
    //    {
    //        Debug.LogError("Save file not found in " + path);
    //        return null;
    //    }
    //}

}
