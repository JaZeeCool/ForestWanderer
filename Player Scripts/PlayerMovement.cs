using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController character_Controller;

    private Vector3 move_Direction; // What is the dirrection we are mvoing to

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_force = 10f;
    private float vertical_Velocity;

    void Awake() {
        character_Controller = GetComponent<CharacterController>();
    }

    void Update() {
        MoveThePlayer();
    }

    void MoveThePlayer() {

        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f,
                                     Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_Controller.Move(move_Direction);


    } // move player

    void ApplyGravity() {

        vertical_Velocity -= gravity * Time.deltaTime;

        // jump
        PlayerJump();

        move_Direction.y = vertical_Velocity * Time.deltaTime;

    } // apply gravity

    void PlayerJump() {

        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) { // Pressing space will allow to jump
            vertical_Velocity = jump_force;
        }

    }

} // class