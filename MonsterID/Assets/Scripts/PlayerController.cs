using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Must haves
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    //Parameters
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;
    
    void FixedUpdate()
    {
        //Virtual joystick now make player move
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        //player now look at direction its moving towards
        if (_joystick.Horizontal !=0 || _joystick.Vertical !=0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
