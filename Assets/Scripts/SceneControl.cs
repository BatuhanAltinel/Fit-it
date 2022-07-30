using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
   

    public void StartGame()
    {
        Debug.Log(DataManager.instance.gameCoin);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        Debug.Log(DataManager.instance.gameCoin);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
