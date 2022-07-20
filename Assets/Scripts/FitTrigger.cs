using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitTrigger : MonoBehaviour
{
    public string moldTag;
    private bool isTriggered;
    public ParticleSystem fitParticle;
    private float yAxisBoundary;
    // Start is called before the first frame update
    private void Awake()
    {
        isTriggered = false;
        yAxisBoundary = -9.1f;
    }
    void Update()
    {
        DontFitIt();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(moldTag))
        {
            Debug.Log("triggered "+ moldTag +" mold.");
            isTriggered = true;
            //SoundEffect;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FitTrigger") && isTriggered)
        {
            Debug.Log("FÝT TRÝGGERED");
            fitParticle.Play();
            //SoundEffect coin effect
        }
    }

    void DontFitIt()
    {
        if (this.transform.position.y < yAxisBoundary && !isTriggered )
        {
            Debug.Log("dont fit the right place");
            StartCoroutine("WrongplaceDestroyObject");
        }
    }

    IEnumerator WrongplaceDestroyObject()
    {
        
        yield return new WaitForSeconds(0.1f);
        this.transform.parent.parent.gameObject.SetActive(false);
    }

}
