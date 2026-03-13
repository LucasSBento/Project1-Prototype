using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler input;
    private PlayerMovement movement;

    private void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        movement.Move(input.MoveInput);
    }
}
