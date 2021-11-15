using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position;
    }
}
