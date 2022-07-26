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

    public int coin;
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
        maxTaskCount = 4;

        DiskTask(maxTaskCount);
        SquareTask(maxTaskCount);
        CookieTask(maxTaskCount);
        StarTask(maxTaskCount);
        TriangleTask(maxTaskCount);
    }

    public void CoinCounter()
    {
        coinText.text = "x " + coin;
    }

    public void TaskGeneretor(int maxTaskCount)
    {
        maxObjectsCount = Random.Range(10, 18);
        taskCount = Random.Range(1, maxTaskCount);
    }
    void DiskTask(int difficulty)
    {
        TaskGeneretor(difficulty);
        diskText.text = taskCount + "/" + maxObjectsCount;
    }
    void SquareTask(int difficulty)
    {
        TaskGeneretor(difficulty);
        squareText.text = taskCount + "/" + maxObjectsCount;
    }
    void StarTask(int difficulty)
    {
        TaskGeneretor(difficulty);
        starText.text = taskCount + "/" + maxObjectsCount;
    }
    void CookieTask(int difficulty)
    {
        TaskGeneretor(difficulty);
        cookieText.text = taskCount + "/" + maxObjectsCount;
    }
    void TriangleTask(int difficulty)
    {
        TaskGeneretor(difficulty);
        triangleText.text = taskCount + "/" + maxObjectsCount;
    }
}
