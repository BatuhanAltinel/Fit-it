using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    
    [SerializeField] float downSpeed;


    void FixedUpdate()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Trigger"))
       {
         GetComponentInChildren<RotateObjects>().isTriggered = true;
        }
        else if (other.gameObject.CompareTag("LastTrigger"))
        {
            gameObject.SetActive(false);
            GetComponentInChildren<RotateObjects>().isTriggered = true;
        }
    }
}
