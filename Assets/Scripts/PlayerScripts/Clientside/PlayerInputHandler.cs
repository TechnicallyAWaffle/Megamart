using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerMovement playerMovement;

    private Vector2 trueMovementInput;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        trueMovementInput = context.ReadValue<Vector2>();
        Debug.Log("true" + trueMovementInput);
        playerMovement.UpdateMoveInput(trueMovementInput);
    }
}
