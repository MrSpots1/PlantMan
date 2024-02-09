using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;
    public Vector3 velocity = Vector3.zero;
    public CharacterController2D controller;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        if (controller.posY < 5)
        {
            offset.Set(offset.x,1.95f - transform.position.y,offset.z);
        }
       // if (controller.posY >= 5) 
        //{
         //   offset.Set(offset.x, 0f, offset.z); 

//        }
    }
}
