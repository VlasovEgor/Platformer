using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBlocks : MonoBehaviour
{
    public Transform Transform;
    float z;
    public int SpeedRotation=15;
    public float StartRotatin;

    private void Start()
    {
        z = StartRotatin;
    }
    private void Update()
    {
        
        z += Time.deltaTime * SpeedRotation;
        Transform.rotation = Quaternion.Euler(0, 0, -z);
    }
}
