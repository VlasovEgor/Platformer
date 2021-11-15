using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour
{
    public Transform BodyTransform;
    public Transform PistolTransform;


    // Update is called once per frame
    void Update()
    {
        if(PistolTransform.forward.x>0)
        {
            BodyTransform.localRotation = Quaternion.Lerp(BodyTransform.rotation, Quaternion.Euler(0, 50, 0), Time.deltaTime * 5);
        }
        else
        {
            BodyTransform.localRotation = Quaternion.Lerp(BodyTransform.rotation, Quaternion.Euler(0, 120, 0), Time.deltaTime * 5);
        }
    }
}
