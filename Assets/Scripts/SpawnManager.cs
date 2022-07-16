using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _spawnManager;
    public GameObject[] _objectsArray = new GameObject[5];
    int levelIndex = 0;
    float spawnWaitingTime = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (_spawnManager == null)
        {
            _spawnManager = this;
        }
        else
            Destroy(gameObject);
        DontDestroyOnLoad(_spawnManager);

        SpawnShapes();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    Vector3 CalculateSpawnPoint()
    {
        float maxX = Random.Range(-2.2f, 2.2f);
        float maxY = 8.0f;
        Vector3 spawnPoint = new Vector3(maxX, maxY, 0);
        return spawnPoint;
    }

    void SpawnShapes()
    {
        
        if (levelIndex < 6)
        {
            for (int i = 0; i < 1; i++)
            {
                int randomIndex = Random.Range(0, _objectsArray.Length - 2);
                Instantiate(_objectsArray[randomIndex], CalculateSpawnPoint(), Quaternion.identity);
                StartCoroutine("SpawnDelay");
            }
        }
    }
    IEnumerator SpawnDelay()
    {
        
        yield return new WaitForSeconds(spawnWaitingTime);
        StartCoroutine("SpawnShapes");
    }
}
