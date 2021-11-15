using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHealth : MonoBehaviour
{
    public int HealthValue=1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(HealthValue);
            Destroy(gameObject);
        }
    }
}
