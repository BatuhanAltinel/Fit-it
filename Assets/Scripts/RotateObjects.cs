using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{

    [SerializeField] float rotateSpeed;
    
    private bool isRotating;
    public bool isTriggered ;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = true;
        isTriggered = false;
    }

    void FixedUpdate()
    {
        RotatingObject();
        StopRotating();
        
    }
    
    void RotatingObject()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        }
    }
    void StopRotating()
    {
        if (isTriggered)
        {
            if (this.transform.eulerAngles.x >= 0 && this.transform.eulerAngles.x <= 10)
            {
                Debug.Log("x rot 0 now.");
                transform.rotation = Quaternion.Euler(0, 0, 0);
                isRotating = false;
            }
        }
    }


}
