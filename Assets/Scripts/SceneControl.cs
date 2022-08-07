using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class SceneControl : MonoBehaviour
{
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseGame()
    {
        LevelManager.levelManager.pauseButton.gameObject.SetActive(false);
        LevelManager.levelManager.resumeButton.gameObject.SetActive(true);
        LevelManager.levelManager.isGameOver = true;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        LevelManager.levelManager.pauseButton.gameObject.SetActive(true);
        LevelManager.levelManager.resumeButton.gameObject.SetActive(false);
        LevelManager.levelManager.isGameOver = false;
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
