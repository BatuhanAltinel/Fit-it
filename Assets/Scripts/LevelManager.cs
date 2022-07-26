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



    [HideInInspector]public int coin;
    public Text coinText;
    public Text diskText;
    public Text cookieText;
    public Text squareText;
    public Text triangleText;
    public Text starText;
    
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
    private void Start()
    {
        maxTaskCount = 9;

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
        maxObjectsCount = Random.Range(10, 18);
        taskCount = Random.Range(1, maxTaskCount);
    }
    public void DiskTask()
    {
        TaskGeneretor();
        diskTaskCount = taskCount;
        WriteDisks();
    }
    public void WriteDisks()
    {
        diskText.text = diskTaskCount + "/" + maxObjectsCount;
    }
    public void SquareTask()
    {
        TaskGeneretor();
        squareTaskCount = taskCount;
        WriteSquares();
    }
    public void WriteSquares()
    {
        squareText.text = squareTaskCount + "/" + maxObjectsCount;
    }
    public void StarTask()
    {
        TaskGeneretor();
        starTaskCount = taskCount;
        WriteStars();
    }
    public void WriteStars()
    {
        starText.text = starTaskCount + "/" + maxObjectsCount;
    }
    public void CookieTask()
    {
        TaskGeneretor();
        cookieTaskCount = taskCount;
        WriteCookies();
    }
    public void WriteCookies()
    {
        cookieText.text = cookieTaskCount + "/" + maxObjectsCount;
    }
    public void TriangleTask()
    {
        TaskGeneretor();
        triangleTaskCount = taskCount;
        WriteTriangles();
    }
    public void WriteTriangles()
    {
        triangleText.text = triangleTaskCount + "/" + maxObjectsCount;
    }
}
