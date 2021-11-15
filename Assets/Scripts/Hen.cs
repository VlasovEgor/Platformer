using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private Transform _playerTransform;
    public float Speed = 3f;
    public float TimeToReachSpeed=1f;
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    private void FixedUpdate()
    {
        Vector3 ToPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 Force = Rigidbody.mass * (ToPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;

        Rigidbody.AddForce(Force);
    }
}
