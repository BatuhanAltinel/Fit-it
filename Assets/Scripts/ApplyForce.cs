using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody myBody;
    [SerializeField] float downSpeed;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        myBody.AddForce(Vector3.down * downSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Trigger"))
       {
         Debug.Log("Triggered..");
         GetComponentInChildren<RotateObjects>().isTriggered = true;
        }
        else if (other.gameObject.CompareTag("LastTrigger"))
        {
            gameObject.SetActive(false);
        }
    }
}
