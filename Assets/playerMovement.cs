using UnityEngine;
using UnityEngine.InputSystem;
// using System.Collections;
// using System.Collections.Generic;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float turnInput;
    private float forwardInput;
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

        Vector3 forwardMove = transform.forward * (forwardInput * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + forwardMove);
    }

    private void OnMove(InputValue movementValue)
    {
        Debug.Log("OnMove");
        Vector2 movementVector = movementValue.Get<Vector2>();
        turnInput = movementVector.x;
        forwardInput = movementVector.y;
    }
}
