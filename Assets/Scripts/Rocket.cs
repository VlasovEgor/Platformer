using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    private Transform _playertransform;
    void Start()
    {
        _playertransform = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward*Speed;
        Vector3 toPlayer = _playertransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer,Vector3.forward);

        transform.rotation =Quaternion.Lerp(transform.rotation, targetRotation,Time.deltaTime*RotationSpeed);
    }
}
