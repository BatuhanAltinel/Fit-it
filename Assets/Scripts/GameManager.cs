using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [HideInInspector]public bool isSlidingDone;
    [HideInInspector] public bool isGameStarted;

    //public static SaveData coinData;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
            Destroy(gameObject);
        isGameStarted = false;
        isSlidingDone = false;
    }
    

}
