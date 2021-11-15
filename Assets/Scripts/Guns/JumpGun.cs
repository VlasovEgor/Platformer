using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed;
    public Transform Spawn;
    public Gun Pistol;
    public GhargeIcon GhargeIcon;
    public float MaxCharge=3;
    private float _currentCharge;
    private bool _isChared;

    private void Update()
    {
        _currentCharge += Time.deltaTime;

        if(_isChared)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayerRigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                Pistol.Shot();
                _isChared = false;
                _currentCharge = 0;
                GhargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            GhargeIcon.SetChargeValue(_currentCharge, MaxCharge);
            if (_currentCharge>=MaxCharge)
            {
                _isChared = true;
                GhargeIcon.StopCharge();
            }
        }
        
    }
}
