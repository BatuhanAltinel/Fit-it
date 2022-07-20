using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitTrigger : MonoBehaviour
{
    public string moldTag;
    private bool isTriggered;
    public ParticleSystem fitParticle;
    // Start is called before the first frame update
    private void Awake()
    {
        isTriggered = false;
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
            //fitParticle.Play();
            //SoundEffect;
            //ParticleEffect;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FitTrigger") && isTriggered)
        {
            Debug.Log("FÝT TRÝGGERED");
            fitParticle.Play();
        }
    }

    void DontFitIt()
    {
        if (this.transform.position.y < -9.1f && !isTriggered )
        {
            Debug.Log("dont fit the right place");
            StartCoroutine("WrongplaceDestroyObject");
        }
    }

    IEnumerator WrongplaceDestroyObject()
    {
        this.transform.parent.parent.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }

}
