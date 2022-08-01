using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public AdsManager ads;
    private int maxTaskCount;
    private int maxObjectsCount;
    private int taskCount;

    public GameObject diskIcon;
    public GameObject cookieIcon;
    public GameObject squareIcon;
    public GameObject starIcon;
    public GameObject triangleIcon;

    public GameObject diskTick;
    public GameObject cookieTick;
    public GameObject squareTick;
    public GameObject starTick;
    public GameObject triangleTick;

    [HideInInspector] public int diskTaskCount;
    [HideInInspector] public int squareTaskCount;
    [HideInInspector] public int starTaskCount;
    [HideInInspector] public int cookieTaskCount;
    [HideInInspector] public int triangleTaskCount;

    [HideInInspector] public int maxDiskCount;
    [HideInInspector] public int maxSquareCount;
    [HideInInspector] public int maxStarCount;
    [HideInInspector] public int maxCookieCount;
    [HideInInspector] public int maxTriangleCount;


    public Text coinText;
    public Text diskText;
    public Text cookieText;
    public Text squareText;
    public Text triangleText;
    public Text starText;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    [HideInInspector] public int levelCompleteNum = 0;

    private bool isCubeOver;
    private bool isDiskOver;
    private bool isStarOver;
    private bool isCookieOver;
    private bool isTriangleOver;
    // Start is called before the first frame update
    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        else
            Destroy(gameObject);

        maxTaskCount = 6;
        DataManager.instance.LoadGameData();
        CoinCounter();
        
    }
    private void Start()
    {
        DiskTask();
        SquareTask();
        CookieTask();
        StarTask();
        TriangleTask();
    }
    private void Update()
    {
        if (levelCompleteNum >= 5)
        {
            levelCompletePanel.gameObject.SetActive(true);
            levelCompleteNum = 0;
            Time.timeScale = 0;
        }
    }

    public void CoinCounter()
    {
        coinText.text = "x " + DataManager.instance.gameCoin;
    }

    public void TaskGeneretor()
    {
        maxObjectsCount = Random.Range(6, 11);
        taskCount = Random.Range(1, maxTaskCount);
    }
    public void DiskTask()
    {
        TaskGeneretor();
        diskTaskCount = taskCount;
        maxDiskCount = maxObjectsCount;
        WriteDisks();
    }
    public void WriteDisks()
    {
        if (diskTaskCount == 0)
        {
            levelCompleteNum++;
            diskTaskCount = -1;
            GameManager.gameManager.GetComponent<ObjectPooling>().isDiskDone = true;
            isDiskOver = true;
            diskIcon.SetActive(false);
            diskTick.SetActive(true);
            // disk uý panel change green tick.
        }
        if (maxDiskCount < diskTaskCount && !isDiskOver)
        {
            maxDiskCount = 0;
            GameOver();
        }
        diskText.text = diskTaskCount + "/" + maxDiskCount;
    }
    public void SquareTask()
    {
        TaskGeneretor();
        squareTaskCount = taskCount;
        maxSquareCount = maxObjectsCount;
        WriteSquares();
    }
    public void WriteSquares()
    {
        if (squareTaskCount == 0)
        {
            levelCompleteNum++;
            squareTaskCount = -1;
            GameManager.gameManager.GetComponent<ObjectPooling>().isCubeDone = true;
            isCubeOver = true;
            squareIcon.SetActive(false);
            squareTick.SetActive(true);
        }
        if (maxSquareCount < squareTaskCount && !isCubeOver)
        {
            maxSquareCount = 0;
            GameOver();
        }
        squareText.text = squareTaskCount + "/" + maxSquareCount;
    }
    public void StarTask()
    {
        TaskGeneretor();
        starTaskCount = taskCount;
        maxStarCount = maxObjectsCount;
        WriteStars();
    }
    public void WriteStars()
    {
        if (starTaskCount == 0)
        {
            levelCompleteNum++;
            starTaskCount = -1;
            GameManager.gameManager.GetComponent<ObjectPooling>().isStarDone = true;
            isStarOver = true;
            starIcon.SetActive(false);
            starTick.SetActive(true);
        }
        if (maxStarCount < starTaskCount && !isStarOver)
        {
            maxStarCount = 0;
            GameOver();
        }
        starText.text = starTaskCount + "/" + maxStarCount;
    }
    public void CookieTask()
    {
        TaskGeneretor();
        cookieTaskCount = taskCount;
        maxCookieCount = maxObjectsCount;
        WriteCookies();
    }
    public void WriteCookies()
    {
        if (cookieTaskCount == 0)
        {
            levelCompleteNum++;
            cookieTaskCount = -1;
            GameManager.gameManager.GetComponent<ObjectPooling>().isCookieDone = true;
            isCookieOver = true;
            cookieIcon.SetActive(false);
            cookieTick.SetActive(true);
        }
        if (maxCookieCount < cookieTaskCount && !isCookieOver)
        {
            maxCookieCount = 0;
            GameOver();
        }
        cookieText.text = cookieTaskCount + "/" + maxCookieCount;
    }
    public void TriangleTask()
    {
        TaskGeneretor();
        triangleTaskCount = taskCount;
        maxTriangleCount = maxObjectsCount;
        WriteTriangles();
    }
    public void WriteTriangles()
    {
        if (triangleTaskCount == 0)
        {
            levelCompleteNum++;
            triangleTaskCount = -1;
            GameManager.gameManager.GetComponent<ObjectPooling>().isTriangelDone = true;
            isTriangleOver = true;
            triangleIcon.SetActive(false);
            triangleTick.SetActive(true);
        }
        if (maxTriangleCount < triangleTaskCount && !isTriangleOver)
        {
            maxTriangleCount = 0;
            GameOver();
        }
        triangleText.text = triangleTaskCount + "/" + maxTriangleCount;
    }
    void GameOver()
    {
        DataManager.instance.LoadGameData();
        gameOverPanel.gameObject.SetActive(true);
        DataManager.instance.SaveGameData();
        Time.timeScale = 0;
        if(DataManager.instance.gameOverCountsForAds == 2)
        {
            ads.PlayAd();
            DataManager.instance.gameOverCountsForAds = 0;
            
        }
    }

}
