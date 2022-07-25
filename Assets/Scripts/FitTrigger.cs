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
        yAxisBoundary = -9.1f;
    }
    private void OnEnable()
    {
        isTriggered = false;
    }
    void Update()
    {
        DontFitIt();
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(moldTag))
        {
            Debug.Log("triggered " + moldTag + " mold.");
            isTriggered = true;
            
        }
        if (other.gameObject.CompareTag("FitTrigger") && isTriggered)
        {
            Debug.Log("FÝT TRÝGGERED");
            fitParticle.Play();
            SoundManager.instance.PlaySmoothSwipe();
            SoundManager.instance.PlaycollectSound();
            LevelManager.levelManager.coin++;
            LevelManager.levelManager.CoinCounter();
        }
    }

    void DontFitIt()
    {
        if (this.transform.position.y < yAxisBoundary && !isTriggered )
        {
            Debug.Log("dont fit the right place");
            dontFitParticle.Play();
            SoundManager.instance.PlayBangSound();
            //StartCoroutine("WrongplaceDestroyObject");
            this.transform.parent.GetComponent<MeshRenderer>().enabled = false;
            isTriggered = true;
        }
    }

    //IEnumerator WrongplaceDestroyObject()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    this.transform.parent.parent.gameObject.SetActive(false);
    //}

}
