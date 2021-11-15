using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    public float RotationSpeed=3;
    private Vector3 _targetEuler;
    private Transform _playertreansform;
    void Start()
    {
        _playertreansform = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<_playertreansform.position.x)
        {
            _targetEuler = RightEuler;
        }
        else
        {
            _targetEuler = LeftEuler;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
