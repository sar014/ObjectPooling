using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movSpeed = 10.0f;
    float horizontalInput;
    Vector3 MovDirection;
    Rigidbody m_RigidBody;
    void Start()
    {
        m_RigidBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        MovDirection = new Vector3(horizontalInput, 0,0);
    }

    void FixedUpdate()
    {
        m_RigidBody.MovePosition(transform.position + MovDirection * movSpeed * Time.fixedDeltaTime);
    }
}
