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

        if (transform.position.x > 12.6f)
        {
            this.transform.position = new Vector3(12.6f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -6.2f)
        {
            this.transform.position = new Vector3(-6.2f, transform.position.y, transform.position.z);
        }
    }
}
