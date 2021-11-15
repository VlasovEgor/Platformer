using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform _playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
    }

    
}
