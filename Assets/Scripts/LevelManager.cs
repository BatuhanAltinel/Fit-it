using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    private int maxTaskCount;
    private int maxObjectsCount;
    private int taskCount;
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



    [HideInInspector]public int coin;
    public Text coinText;
    public Text diskText;
    public Text cookieText;
    public Text squareText;
    public Text triangleText;
    public Text starText;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        else
            Destroy(gameObject);

        coin = 0;
        maxTaskCount = 6;

    }
    private void Start()
    {
        DiskTask();
        SquareTask();
        CookieTask();
        StarTask();
        TriangleTask();
    }

    public void CoinCounter()
    {
        coinText.text = "x " + coin;
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
        if (diskTaskCount <= 0)
        {
            diskTaskCount = 0;
            //dont spawn any disk.
        }
        if (maxDiskCount < diskTaskCount)
        {
            maxDiskCount = 0;
            gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
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
        if (squareTaskCount <= 0)
        {
            squareTaskCount = 0;
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
        if (starTaskCount <= 0)
        {
            starTaskCount = 0;
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
        if (cookieTaskCount <= 0)
        {
            cookieTaskCount = 0;
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
        if (triangleTaskCount <= 0)
        {
            triangleTaskCount = 0;
        }
        triangleText.text = triangleTaskCount + "/" + maxTriangleCount;
    }

}
