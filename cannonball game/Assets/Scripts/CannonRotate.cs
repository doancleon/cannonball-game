using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    public float RotateSpeed = 30f;
    public Transform playerTransform;
    public Animator cannon_animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            cannon_animator.SetBool("isRotatingRight", true);
            cannon_animator.SetBool("isRotatingLeft", false);

            playerTransform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            cannon_animator.SetBool("isRotatingLeft", true);
            cannon_animator.SetBool("isRotatingRight", false);
            playerTransform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        else 
        {
            cannon_animator.SetBool("isRotatingRight", false);
            cannon_animator.SetBool("isRotatingLeft", false);

        }
    }
 
}
