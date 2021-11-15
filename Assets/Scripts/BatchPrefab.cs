using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefab : MonoBehaviour
{

    public GameObject Prefab;
    public Transform[] Spawns;
    [ContextMenu("Creat")]
   public  void Creat()
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            Instantiate(Prefab, Spawns[i].position, Spawns[i].rotation);
        }
    }
}
