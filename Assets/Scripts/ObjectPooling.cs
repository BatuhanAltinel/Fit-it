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

    private int amountOfObject = 4;

    
    void Awake()
    {
        cubesParent = GameObject.Find("Cubes");
        cookiesParent = GameObject.Find("Cookies");
        disksParent = GameObject.Find("Disks");
        starsParent = GameObject.Find("Stars");
        trianglesParent = GameObject.Find("Triangles");

        CreateCubesFirstStart();
        SpawnCubes();
    }
    private void Start()
    {
        
    }

    void SpawnCubes()
    {
        GetFromPool().transform.position = GetVector();
        GetFromPool().SetActive(true);
        StartCoroutine("DelaySpawn");
        
    }

    GameObject GetFromPool()
    {
        foreach (GameObject cube in cubesQueue)
        {
            if (cube.activeInHierarchy == false)
            {
                return cube;
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
        yield return new WaitForSeconds(5.5f);
        StartCoroutine("SpawnCubes");
    }

    private void CreateCubesFirstStart()
    {
        for (int i = 0; i < amountOfObject; i++)
        {
            cubesInstantiate = Instantiate(cubePref);
            cubesInstantiate.transform.parent = cubesParent.transform;
            cubesInstantiate.gameObject.SetActive(false);
            cubesQueue.Enqueue(cubesInstantiate);

        }
    }

}
