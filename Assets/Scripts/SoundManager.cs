using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;

    public AudioClip smoothSwipeSound;
    public AudioClip bangSound;
    //public AudioClip backgroundSound;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    public void PlaySmoothSwipe()
    {
        audioSource.PlayOneShot(smoothSwipeSound);
    }
    public void PlayBangSound()
    {
        audioSource.PlayOneShot(bangSound);
    }

   
}
