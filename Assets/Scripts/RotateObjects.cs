using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{

    [SerializeField] float rotateSpeed;
    
    private bool isRotating;
    public bool isTriggered;
    public float yRotation;
    public int rotateDirection =1;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = true;
        isTriggered = false;
    }
    private void OnEnable()
    {
        isRotating = true;
        isTriggered = false;
    }

    void FixedUpdate()
    {
        RotatingObject(rotateDirection);
        StopRotating(yRotation);
        BoundaryZAxis();
        
    }
    
    void RotatingObject(int rotateDirection)
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.left * rotateDirection, rotateSpeed * Time.deltaTime);
        }
    }
    void StopRotating(float yRot)
    {
        if (isTriggered)
        {
            if (this.transform.eulerAngles.x >= 0 && this.transform.eulerAngles.x <= 10)
            {
                transform.rotation = Quaternion.Euler(0, yRot, 0);
                isRotating = false;
            }
        }
    }

    void BoundaryZAxis()
    {
        if (this.transform.position.z < 0 ||this.transform.position.z > 0)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }


}
