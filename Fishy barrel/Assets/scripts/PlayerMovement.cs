using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public Transform fake;

    public float moveSmoothTime;
    public float speed = 12f;
    public float gravity = 9.81f;
    public float jumpHeight = 9f;

    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    private Vector3 currentForceVelocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };
        //Creating a unit vector in order to guage direction
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        //Converting player input vector to one that is relative to player direction
        Vector3 moveVector = fake.transform.TransformDirection(PlayerInput);
        if (Physics.Raycast(groundCheckRay, 1.4f/*length of ray*/))
        {
            currentMoveVelocity = Vector3.SmoothDamp(
                currentMoveVelocity,
                moveVector * speed,
                ref moveDampVelocity,
                moveSmoothTime
            );
        }
        controller.Move(currentMoveVelocity * Time.deltaTime);

        //jumping & gravity
        if (Physics.Raycast(groundCheckRay, 1.1f/*length of ray*/))
        {
            currentForceVelocity.y = -20f;
            if (Input.GetKey(KeyCode.Space))
            {
                currentForceVelocity.y = jumpHeight;
            }
        }
        else
        {
            currentForceVelocity.y -= gravity * Time.deltaTime;
        }
        controller.Move(currentForceVelocity * Time.deltaTime);
    }
}
