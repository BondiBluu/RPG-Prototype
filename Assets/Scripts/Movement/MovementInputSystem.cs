using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputSystem : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    public Animator animator;
    [SerializeField] int walkSpeed = 5;
    bool isWalking = false;
    [SerializeField] int runSpeed = 7;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
    }

    void OnMove(InputValue value)
    {
        //storing the values we get as inputs. this is needed in the new input system
        moveInput = value.Get<Vector2>();
        isWalking = true;
        if (isWalking == true)
        {
            Debug.Log("Is walking");
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetFloat("Speed", moveInput.magnitude);  //magnitude: length of our movement vector- our speed

        }

    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * walkSpeed, moveInput.y * walkSpeed);
        myRigidbody.velocity = playerVelocity;

    }

    //trying to get it to run
    void OnRunButton(InputValue value)
    {
        if (isWalking == true && value.isPressed)
        {
            Debug.Log("is running");
            Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * runSpeed);
            myRigidbody.velocity = playerVelocity;
        }
    }
}

