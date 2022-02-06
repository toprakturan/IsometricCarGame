using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSuspension : MonoBehaviour
{
    [SerializeField] private float _suspensionValue;
    Vector3 parentRotation = new Vector3();
    
    void Start()
    {
        
    }

    
    void Update()
    {
        parentRotation = transform.parent.rotation.eulerAngles;

        if (Input.GetKey(KeyCode.D))
        {
            
            //transform.localRotation = Quaternion.Euler(0f, 0f, _suspensionValue);
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, _suspensionValue),5f);
            
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            
            if (Input.GetKey(KeyCode.A))
            {
                transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, -_suspensionValue),5f);
                
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                
            }
        }

        

        
    }
}
