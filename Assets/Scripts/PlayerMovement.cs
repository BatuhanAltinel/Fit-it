using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private float moveSpeed = .01f;
    private int directionValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

        if (transform.position.x > 13.8f)
        {
            this.transform.position = new Vector3(13.8f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -7.4f)
        {
            this.transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
        }
    }
}
