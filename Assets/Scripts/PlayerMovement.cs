using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private float moveSpeed = .02f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                PlayerMove();
            }
        }
    }

    public void PlayerMove()
    {
        transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * moveSpeed ,
                            transform.position.y, transform.position.z);

        if (transform.position.x > 15.2f)
        {
            this.transform.position = new Vector3(15.2f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -8.95f)
        {
            this.transform.position = new Vector3(-8.95f, transform.position.y, transform.position.z);
        }
    }
}
