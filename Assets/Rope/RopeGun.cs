using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RopeState
{
    Disabled,
    Fly,
    Active
}
public class RopeGun : MonoBehaviour
{


    public Hook Hook;
    public Transform Spawn;
    public float Speed;
    private float _length;
    public RopeState CurrentRopeState;
    public SpringJoint SpringJoint;
    public Transform RopeStart;
    public RopeRenderer RopeRenderer;
    public PlayerMove PlayerMove;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shot();
        }
        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 15)
            {
                RopeDisconnection();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentRopeState == RopeState.Active)
                    PlayerMove.Jump();
            DestroySpring();
        }
        if (Input.GetKey(KeyCode.W) && _length >= 1f && CurrentRopeState == RopeState.Active)
        {
            _length -= 0.05f;
            SpringJoint.maxDistance = _length;

        }
        if (Input.GetKey(KeyCode.S) && _length <= 14f && CurrentRopeState == RopeState.Active)
        {
            _length += 0.05f;
            SpringJoint.maxDistance = _length;
        }
        if (CurrentRopeState == RopeState.Active || CurrentRopeState == RopeState.Fly)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _length);
        }

    }
    void Shot()
    {
        _length = 1f;
        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }
        Hook.gameObject.SetActive(true);
        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }

    public void CreatSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _length = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _length;
            CurrentRopeState = RopeState.Active;
        }

    }
    private void RopeDisconnection()
    {
        Hook.gameObject.SetActive(false);
        CurrentRopeState = RopeState.Disabled;
        RopeRenderer.Hide();
    }
    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
