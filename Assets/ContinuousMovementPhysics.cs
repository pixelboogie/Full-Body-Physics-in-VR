using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinuousMovementPhysics : MonoBehaviour
{

    public float speed = 1;
    public InputActionProperty moveInputSource;
    public Rigidbody rb;
    public LayerMask groundLayer;
    public Transform directionSource;
    public CapsuleCollider bodyCollider;
    private Vector2 inputMoveAxis;



    void Update()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>();
    }

    void FixedUpdate(){

        bool isGrounded = CheckIfGrounded();

        if(isGrounded){
            Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y,0);
            Vector3 direction = yaw * new Vector3(inputMoveAxis.x, 0, inputMoveAxis.y);

            rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * speed);
        }
    }

    public bool CheckIfGrounded(){
        Vector3 start = bodyCollider.transform.TransformPoint(bodyCollider.center);
        float rayLength = bodyCollider.height / 2 - bodyCollider.radius + 0.05f;

        bool hasHit = Physics.SphereCast(start, bodyCollider.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);

        return hasHit;
    }
}
