using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitTrigger : MonoBehaviour
{
    public string moldTag;
    private bool isTriggered;
    public ParticleSystem fitParticle;
    public ParticleSystem dontFitParticle;
    private float yAxisBoundary;
    // Start is called before the first frame update
    private void Awake()
    {
        yAxisBoundary = -7.9f;
    }
    private void OnEnable()
    {
        isTriggered = false;
    }
    void Update()
    {
        DontFitIt();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(moldTag))
        {
            Debug.Log("triggered " + moldTag + " mold.");
            isTriggered = true;
            
        }
        if (other.gameObject.CompareTag("FitTrigger") && isTriggered && !LevelManager.levelManager.isGameOver)
        {
            Debug.Log("FÝT TRÝGGERED");
            fitParticle.Play();
            SoundManager.instance.PlaySmoothSwipe();
            SoundManager.instance.PlaycollectSound();
            DataManager.instance.gameCoin++;
            LevelManager.levelManager.CoinCounter();
            DataManager.instance.SaveGameData();

            if (this.gameObject.CompareTag("Disk"))
            {
                LevelManager.levelManager.diskTaskCount--;
                LevelManager.levelManager.maxDiskCount--;
                LevelManager.levelManager.WriteDisks();
            }
            if (this.gameObject.CompareTag("Cookie"))
            {
                LevelManager.levelManager.cookieTaskCount--;
                LevelManager.levelManager.maxCookieCount--;
                LevelManager.levelManager.WriteCookies();
            }
            if (this.gameObject.CompareTag("Star"))
            {
                LevelManager.levelManager.starTaskCount--;
                LevelManager.levelManager.maxStarCount--;
                LevelManager.levelManager.WriteStars();
            }
            if (this.gameObject.CompareTag("Square"))
            {
                LevelManager.levelManager.squareTaskCount--;
                LevelManager.levelManager.maxSquareCount--;
                LevelManager.levelManager.WriteSquares();
            }
            if (this.gameObject.CompareTag("Triangle"))
            {
                LevelManager.levelManager.triangleTaskCount--;
                LevelManager.levelManager.maxTriangleCount--;
                LevelManager.levelManager.WriteTriangles();
            }
        }
    }

    void DontFitIt()
    {
        if (this.transform.position.y < yAxisBoundary && !isTriggered && !LevelManager.levelManager.isGameOver)
        {
            Debug.Log("dont fit the right place");
            dontFitParticle.Play();
            SoundManager.instance.PlayBangSound();
            this.transform.parent.GetComponent<MeshRenderer>().enabled = false;
            isTriggered = true;

            if (this.gameObject.CompareTag("Disk"))
            {
                LevelManager.levelManager.maxDiskCount--;
                LevelManager.levelManager.WriteDisks();
            }
            if (this.gameObject.CompareTag("Cookie"))
            {
                LevelManager.levelManager.maxCookieCount--;
                LevelManager.levelManager.WriteCookies();
            }
            if (this.gameObject.CompareTag("Star"))
            {
                LevelManager.levelManager.maxStarCount--;
                LevelManager.levelManager.WriteStars();
            }
            if (this.gameObject.CompareTag("Square"))
            {
                LevelManager.levelManager.maxSquareCount--;
                LevelManager.levelManager.WriteSquares();
            }
            if (this.gameObject.CompareTag("Triangle"))
            {
                LevelManager.levelManager.maxTriangleCount--;
                LevelManager.levelManager.WriteTriangles();
            }
        }
        
    }

}
