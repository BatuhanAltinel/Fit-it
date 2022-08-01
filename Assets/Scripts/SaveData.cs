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
    private int isSlide;
    private int gameOverForAds;

    public int GameOverForAds
    {
        get { return gameOverForAds; }
        set { gameOverForAds = value; }
    }

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
    public int IsSlide
    {
        get{ return isSlide;}
        set{ isSlide = value; }
    }


}
