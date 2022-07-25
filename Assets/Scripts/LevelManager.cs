using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public int coin;
    public Text coinText;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        else
            Destroy(levelManager);
        DontDestroyOnLoad(levelManager);

        coin = 0;
    }
   
    public void CoinCounter()
    {
        coinText.text = "x " + coin;
    }
}
