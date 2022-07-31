using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    
    [SerializeField] float downSpeed;


    void FixedUpdate()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        PositionBoundary();
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
    void PositionBoundary()
    {
        if(this.transform.position.z < 0 || this.transform.position.z > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,0);
        }
        if(this.transform.position.x < -2.2f)
        {
            this.transform.position = new Vector3(-2.1f, this.transform.position.y, this.transform.position.z);
        }
        else if(this.transform.position.x > 2.2f)
        {
            this.transform.position = new Vector3(2.1f, this.transform.position.y, this.transform.position.z);
        }
    }
}
