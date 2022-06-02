using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    public Transform orientation;
    public float moveSpeed;
    float verticalInput;
    public Animator cannon_animator;
    private bool turning;
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
        if (cannon_animator.GetBool("isRotatingRight") == true || cannon_animator.GetBool("isRotatingLeft") == true)
        {
            turning = true;
        }
        else 
        {
            turning = false;
        }
        if (!turning && verticalInput > 0)
        {
            cannon_animator.SetBool("isMoving", true);
        }
        else if (!turning && verticalInput < 0)
        {
            cannon_animator.SetBool("isMovingBack", true);
        }
        else
        {
            cannon_animator.SetBool("isMoving", false);
            cannon_animator.SetBool("isMovingBack", false);
        }
        if (!turning)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }
    void Update()
    {
        MyInput();

     }
}
