using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    public Transform orientation;
    public float moveSpeed;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void MyInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    void Update()
    {
        MyInput();

     }
}
