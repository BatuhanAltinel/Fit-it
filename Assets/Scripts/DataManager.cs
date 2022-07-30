using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private SaveData saveData;

    [HideInInspector] public int gameCoin;
    private string gameDataPath = "/coinData.batu";
    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
        InitializeGameData();
    }
    private void Start()
    {
        Debug.Log(Application.persistentDataPath + gameDataPath);
    }
    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }else if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void InitializeGameData()
    {
        LoadGameData();

        // first time game launched
        if (saveData == null)
        {
            gameCoin = 0;

            saveData = new SaveData();

            saveData.Coin = gameCoin;
            SaveGameData();
        }
    }

    public void SaveGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + gameDataPath);

            if (saveData != null)
            {
                saveData.Coin = gameCoin;

                bf.Serialize(file, saveData);
            }
            
        }
        catch (Exception e)
        {

        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    public void LoadGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + gameDataPath, FileMode.Open);

            saveData = (SaveData)bf.Deserialize(file);

            if (saveData != null)
            {
                gameCoin = saveData.Coin;
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

}
