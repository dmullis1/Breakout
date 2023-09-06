using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputAction move;
    private InputAction restart;
    private InputAction quit;

    private bool isPaddleMoving;
    [SerializeField]private GameObject paddle;
    [SerializeField]private float paddleSpeed;
    private float moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerInput.currentActionMap.Enable();

        move = playerInput.currentActionMap.FindAction("MovePaddle");
        restart = playerInput.currentActionMap.FindAction("RestartGame");
        quit = playerInput.currentActionMap.FindAction("QuitGame");

        move.started += Move_started;
        move.canceled += Move_canceled;
        restart.started += Restart_started;
        quit.started += Quit_started;

        isPaddleMoving = false;

    }

    private void Quit_started(InputAction.CallbackContext context)
    {
    }

    private void Restart_started(InputAction.CallbackContext context)
    {
    }

    private void Move_canceled(InputAction.CallbackContext context)
    {
        isPaddleMoving = false;
    }

    private void Move_started(InputAction.CallbackContext context)
    {
        isPaddleMoving = true;
    }
    private void FixedUpdate()
    {
        if (isPaddleMoving) 
        {
            paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(paddleSpeed * moveDirection, 0);
        }
        else 
        {
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaddleMoving) 
        {
            moveDirection = move.ReadValue<float>();
        }
    }
}
