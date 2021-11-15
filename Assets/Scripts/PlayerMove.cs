using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;
    private float _angle;
    private int _jumpFrameCounter;


    public float MaxSpeed;
    public Transform Transform;
    public Transform PlayerTransform;
    public RopeGun RopeGun;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)|| Input.GetKey(KeyCode.S)|| Grounded==false)
            Transform.localScale=Vector3.Lerp(Transform.localScale,new Vector3(1, 0.5f, 1),Time.deltaTime*15);
        else Transform.localScale = Vector3.Lerp(Transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 15);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true) Jump();
    }
    public void Jump()
    {
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
        
    }
    private void FixedUpdate()
    {
        float speedMultiplier = 1;
        if(Grounded==false)
        {
            speedMultiplier = 0.2f;
            if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }

        float _ropeSpeedMult = 1f;
        if(RopeGun.CurrentRopeState==RopeState.Active &&!Grounded)
        {
            _ropeSpeedMult = 0.1f;
        }
       
        Rigidbody.AddForce(Input.GetAxis("Horizontal")*MoveSpeed* speedMultiplier* _ropeSpeedMult, 0, 0,ForceMode.VelocityChange);

        if(Grounded==true)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 25);
        }
       
        //_jumpFrameCounter += 1;
        //if(_jumpFrameCounter==2)
      //  {
         //   Rigidbody.freezeRotation = false;
         //   Rigidbody.AddRelativeTorque(0, 0, 2, ForceMode.VelocityChange);
      //  }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        _angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (_angle < 45f)
        {
            Grounded = true;
            Rigidbody.freezeRotation = true;
        }
    }
        private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
