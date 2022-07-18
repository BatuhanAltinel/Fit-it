using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitTrigger : MonoBehaviour
{
    public string moldTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(moldTag))
        {
            Debug.Log("Cube triggered "+ moldTag +" mold.");
            //SoundEffect;
            //ParticleEffect;
        }
    }
}
