using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 20f;
    public float runSpeed = 40f;

    Transform viewPoint;
    CharacterController charCon;
    private float activeMoveSpeed; // Controls how much move speed we are applying to the player
    private Vector3 moveDir, movement;

    void Start()
    {
        charCon = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None;
        viewPoint = transform;
    }

    void Update()
    {
        HorizontalVerticalPlayerMovement();
    }

    void HorizontalVerticalPlayerMovement()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift)) // left shift key is pressed, run faster
        {
            activeMoveSpeed = runSpeed;
        }
        else
        {
            activeMoveSpeed = moveSpeed;
        }

        // Dont move diagonally faster than forward or right
        float yVel = movement.y;
        movement = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized * activeMoveSpeed;
        movement.y = yVel;

        charCon.Move(movement * Time.deltaTime);
    }
}
