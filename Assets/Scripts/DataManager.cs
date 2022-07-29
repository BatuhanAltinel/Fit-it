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
    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
        InitializeGameData();
    }
    private void Start()
    {
        Debug.Log(Application.persistentDataPath + "/coinData.dat");
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

            saveData.coin = gameCoin;
            SaveGameData();
        }
    }

    public void SaveGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + "/coinData.dat");

            if (saveData != null)
            {
                saveData.coin = gameCoin;

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

    void LoadGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + "/coinData.dat",FileMode.Open);

            saveData = (SaveData)bf.Deserialize(file);

            if (saveData != null)
            {
                gameCoin = saveData.coin;
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
