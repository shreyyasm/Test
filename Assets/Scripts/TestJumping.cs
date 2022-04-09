 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestJumping : MonoBehaviour
{
    Rigidbody myBody;
    PlayerInput playerInput;
    PlayerInputActions playerInputActions;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;

        playerInputActions.Player.Movement.performed += Movement_Performed;
    }
    
    void Update()
    {
        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("UI");
        }
        if(Keyboard.current.yKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("Player");
        }
    }
    void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 5f;
        myBody.AddForce(new Vector3(inputVector.x , 0 , inputVector.y) * speed, ForceMode.Force);
    }
    private void Movement_Performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 inputVector =  context.ReadValue<Vector2>();
        float speed = 5f;
        myBody.AddForce(new Vector3(inputVector.x , 0 , inputVector.y) * speed, ForceMode.Force);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if(context.performed)
        {
            Debug.Log("Jump" + context.phase);
            myBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        
    }
    public void Submit(InputAction.CallbackContext context)
    {
        Debug.Log("Submit" + context);
        
    }
}
