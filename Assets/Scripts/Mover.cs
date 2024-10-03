using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    private Rigidbody _rigidbody;
    private float _hotizontal;
    private float _vertical;
    private Vector3 _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _hotizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _movement = new Vector3(_hotizontal, 0.0f, _vertical);
        _rigidbody.AddForce(_movement * _speed);
    }
}
