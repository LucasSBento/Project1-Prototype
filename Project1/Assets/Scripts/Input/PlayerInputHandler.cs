using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions input;
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Awake()
    {
        input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Jump.performed += OnJump;
        input.Player.Jump.canceled += OnJumpReleased;
    }

    private void OnDisable()
    {
        input.Player.Jump.performed -= OnJump;
        input.Player.Jump.canceled -= OnJumpReleased;

        input.Disable();
    }

    void Update()
    {
        MoveInput = input.Player.Move.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        JumpPressed = true;
    }

    private void OnJumpReleased(InputAction.CallbackContext ctx)
    {
        JumpPressed = false;
    }
}
