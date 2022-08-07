using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.Play("levelAnim");
        StartCoroutine("DontActiveLevelPanel");
    }
    IEnumerator DontActiveLevelPanel()
    {
        yield return new WaitForSeconds(1.4f);
        gameObject.SetActive(false);
    }

}
