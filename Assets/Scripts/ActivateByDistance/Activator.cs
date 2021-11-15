using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjictsToActivate=new List<ActivateByDistance>();
    public Transform PlayerTransform;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ObjictsToActivate.Count; i++)
        {
            ObjictsToActivate[i].CheckDistance(PlayerTransform.position);
        }
    }
}
