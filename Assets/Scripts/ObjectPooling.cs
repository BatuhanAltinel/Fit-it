using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private Queue<GameObject> cubesQueue = new Queue<GameObject>();
    private Queue<GameObject> cookiesQueue = new Queue<GameObject>();
    private Queue<GameObject> diskQueue = new Queue<GameObject>();
    private Queue<GameObject> starQueue = new Queue<GameObject>();
    private Queue<GameObject> triangleQueue = new Queue<GameObject>();

    public GameObject cubePref;
    public GameObject cookiePref;
    public GameObject diskPref;
    public GameObject starPref;
    public GameObject trianglePref;

    private GameObject cubesParent;
    private GameObject cookiesParent;
    private GameObject disksParent;
    private GameObject starsParent;
    private GameObject trianglesParent;

    private GameObject cubesInstantiate = null;
    private GameObject cookiesInstantiate = null;
    private GameObject disksInstantiate = null;
    private GameObject starsInstantiate = null;
    private GameObject trianglesInstantiate = null;

    public bool isCubeDone;
    public bool isDiskDone;
    public bool isStarDone;
    public bool isCookieDone;
    public bool isTriangelDone;

    private int amountOfObject = 4;
    private int typeOfObjects = 5;
    private float spawnWaitingTime = 5.5f;
    private int randomSelectNumber;


    
    void Awake()
    {
        cubesParent = GameObject.Find("Cubes");
        cookiesParent = GameObject.Find("Cookies");
        disksParent = GameObject.Find("Disks");
        starsParent = GameObject.Find("Stars");
        trianglesParent = GameObject.Find("Triangles");

        CreateObjectsFirstStart();
    }
    private void Start()
    {
        isCubeDone = false;
        isStarDone = false;
        isDiskDone = false;
        isCookieDone = false;
        isTriangelDone = false;
        RandomObjectSpawn();
    }

    void SpawnObjects(Queue<GameObject> newQueue)
    {
        GetFromPool(newQueue).transform.position = GetVector();
        GetFromPool(newQueue).SetActive(true);
        StartCoroutine("DelaySpawn");
        
    }
    
    GameObject GetFromPool(Queue<GameObject> newQueue)
    {
        foreach (GameObject obj in newQueue)
        {
            if (obj.activeInHierarchy == false)
            {
                return obj;
            }
        }
        return null;
    }

    private Vector3 GetVector()
    {
        float maxX = Random.Range(-2.2f, 2.2f);
        float maxY = 8.0f;

        Vector3 spawnPoint = new Vector3(maxX, maxY, 0);
        return spawnPoint;
    }
    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(spawnWaitingTime);
        StartCoroutine("RandomObjectSpawn");
    }

    void RandomObjectSpawn()
    {
        randomSelectNumber = Random.Range(0, typeOfObjects);
        if (LevelManager.levelManager.levelCompleteNum < 5)
        {
            switch (randomSelectNumber)
            {
                case 0:
                    if (!isCubeDone)
                    {
                        SpawnObjects(cubesQueue);
                    }
                    else
                        RandomObjectSpawn();
                    break;
                case 1:
                    if (!isCookieDone)
                    {
                        SpawnObjects(cookiesQueue);
                    }
                    else
                        RandomObjectSpawn();

                    break;
                case 2:
                    if (!isDiskDone)
                    {
                        SpawnObjects(diskQueue);
                    }
                    else
                        RandomObjectSpawn();

                    break;
                case 3:
                    if (!isStarDone)
                    {
                        SpawnObjects(starQueue);
                    }
                    else
                        RandomObjectSpawn();

                    break;
                case 4:
                    if (!isTriangelDone)
                    {
                        SpawnObjects(triangleQueue);
                    }
                    else
                        RandomObjectSpawn();

                    break;

                default:
                    break;
            }
        }
    }

    private void CreateObjectsFirstStart()
    {
        for (int i = 0; i < amountOfObject; i++)
        {
            cubesInstantiate = Instantiate(cubePref);
            cubesInstantiate.transform.parent = cubesParent.transform;
            cubesInstantiate.gameObject.SetActive(false);
            cubesQueue.Enqueue(cubesInstantiate);

            cookiesInstantiate = Instantiate(cookiePref);
            cookiesInstantiate.transform.parent = cookiesParent.transform;
            cookiesInstantiate.SetActive(false);
            cookiesQueue.Enqueue(cookiesInstantiate);

            disksInstantiate = Instantiate(diskPref);
            disksInstantiate.transform.parent = disksParent.transform;
            disksInstantiate.SetActive(false);
            diskQueue.Enqueue(disksInstantiate);

            starsInstantiate = Instantiate(starPref);
            starsInstantiate.transform.parent = starsParent.transform;
            starsInstantiate.SetActive(false);
            starQueue.Enqueue(starsInstantiate);

            trianglesInstantiate = Instantiate(trianglePref);
            trianglesInstantiate.transform.parent = trianglesParent.transform;
            trianglesInstantiate.SetActive(false);
            triangleQueue.Enqueue(trianglesInstantiate);

        }
    }

}
