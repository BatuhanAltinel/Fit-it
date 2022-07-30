using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[Serializable]
public class SaveData
{
    private int coin;

    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
        }
    }


}
