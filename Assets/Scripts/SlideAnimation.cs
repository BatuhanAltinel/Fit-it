using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideAnimation : MonoBehaviour
{
    private Touch touch;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && DataManager.instance.slideNum == 0)
        {
            if(touch.phase == TouchPhase.Began)
            {
                GameManager.gameManager.isGameStarted = true;
                anim.SetInteger("HandSliding", 1);
                DataManager.instance.SaveGameData();
                gameObject.SetActive(false);
            }
        }
        else if(DataManager.instance.slideNum == 1)
            {
                gameObject.SetActive(false);
                GameManager.gameManager.isGameStarted = true;
            }
    }
}
