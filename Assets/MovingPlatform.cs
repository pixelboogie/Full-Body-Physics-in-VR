using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform p1;
    public Transform p2;
    public Rigidbody rb;

    private Vector3 targetPosition;


    void Start()
    {
        targetPosition = p1.position;
    }

    
    void FixedUpdate()
    {
        Vector3 direction = (targetPosition - rb.position).normalized;
        rb.MovePosition(rb.position + speed * direction * Time.fixedDeltaTime);

        if(Vector3.Distance(rb.position, targetPosition) < 0.05f){
            if(targetPosition == p1.position)
                targetPosition = p2.position;
            else
                targetPosition = p1.position;
        }
    }
}
