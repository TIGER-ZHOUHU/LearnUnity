using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    public float jumpVelocity = 5f;

    private float vInput;
    private float hInput;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        
        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rigidbody.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRot);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up*jumpVelocity,ForceMode.Impulse);
        }
        
    }
}
