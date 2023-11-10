using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float horizontalSpeed,
        verticalSpeed;
    [SerializeField] private Transform moveHorizontally,
        moveVertically;
    [SerializeField] private AudioPlay jumpAudio;
    [SerializeField] private LayerMask interactableLayer;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool jumpInput;
    private bool wasGrounded;
    private Vector3 velocity;
    private Transform _transform;

    private Animator animator;
    private PlayerInput input;
    private CharacterController controller;
    
    private bool moveHorizontallyEmpty;
    private bool moveVerticallyEmpty;

    private ApplicationHandler handler;

    private void Awake()
    {
        _transform = transform;
        
        moveHorizontallyEmpty = moveHorizontally == null;
        moveVerticallyEmpty = moveVertically == null;
        
        animator = gameObject.GetComponent<Animator>();
        input = gameObject.GetComponent<PlayerInput>();
        controller = gameObject.GetComponent<CharacterController>();
        handler = FindObjectOfType<ApplicationHandler>();
        
        input.actions["Interact"].performed += OnInteract;
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (!moveHorizontallyEmpty)
        {
            moveHorizontally.Rotate(Vector3.up, lookInput.x * 180 * horizontalSpeed * Time.deltaTime);
        }

        if (!moveVerticallyEmpty)
        {
            moveVertically.Rotate(Vector3.right, lookInput.y * 180 * verticalSpeed * Time.deltaTime);
        }
        
        ApplyGravity();
        
        velocity = transform.TransformDirection(TranslateInputToVector(moveInput));

        if (jumpInput)
        {
            velocity.y = jumpForce;
            jumpInput = false;
        }

        bool isGrounded = controller.isGrounded;

        switch (wasGrounded)
        {
            case true when !isGrounded:
                break;
            case false when isGrounded:
                break;
        }

        wasGrounded = isGrounded;
    }

    private void FixedUpdate()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    private Vector3 TranslateInputToVector(Vector2 input)
    {
        return new Vector3(input.x * speed, velocity.y, input.y * speed);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>().normalized;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized;

        animator.SetBool("Walking", true);

        if (moveInput == Vector2.zero)
        {
            animator.SetBool("Walking", false);
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = true;
            jumpAudio.PlayAudio();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            handler.PauseGame();
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if(!Physics.Raycast(_transform.position + (Vector3.up * .3f) + (_transform.forward * .2f),
               _transform.forward, out RaycastHit hit, 3f, interactableLayer)) return;

        if (!hit.transform.TryGetComponent(out NPC npc)) return;
        
        Debug.Log(npc);
        
        npc.InteractWith();
    }
}
