using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationMethod
{
    LookRotation,
    Angle,
    Euler,
    Slerp,
    FromToRotation,
    identity
}
public class RotationQuaternionEx : MonoBehaviour
{
    public RotationMethod rotationMethod = RotationMethod.identity;
    
    public Transform target;
    
    public Transform from;
    public Transform to;
    public float speed = 0.1F;
    
    void Update()
    {
        Quaternion rotation;
        switch (rotationMethod)
        {
            case RotationMethod.LookRotation:
                Vector3 relativePos = target.position - transform.position;
                target.transform.rotation = Quaternion.LookRotation(relativePos);
                break;
            case RotationMethod.Angle:
                float angle = Quaternion.Angle(transform.rotation, target.rotation);
                Debug.Log(angle);
                break;
            case RotationMethod.Euler:
                target.transform.rotation = Quaternion.Euler(new Vector3(0, 30, 0));
                break;
            case RotationMethod.Slerp:
                target.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
                break;
            case RotationMethod.FromToRotation:
                target.transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
                break;
            case RotationMethod.identity:
                target.transform.rotation = Quaternion.identity;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
}
