using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerPositionSwitcher : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public Transform roomPosition; // The Transform of the player's position inside the room
    public Transform externalPosition; // The Transform of the external viewing point
    public InputActionReference toggleAction; // Input action for switching positions

    private bool isInRoom = true; // Tracks whether the player is in the room or external viewing point

    private void Start()
    {
        // Enable the input action
        toggleAction.action.Enable();

        // Attach the callback to toggle positions
        toggleAction.action.performed += TogglePosition;
    }

    private void TogglePosition(InputAction.CallbackContext context)
    {
        if (player != null)
        {
            // Switch the player's position based on the current state
            if (isInRoom)
            {
                player.transform.position = externalPosition.position;
                player.transform.rotation = externalPosition.rotation;
            }
            else
            {
                player.transform.position = roomPosition.position;
                player.transform.rotation = roomPosition.rotation;
            }
            Debug.Log("Position changed");
            // Toggle the state
            isInRoom = !isInRoom;
        }
        else
        {
            Debug.LogWarning("Player reference is missing.");
        }
    }

    private void OnDestroy()
    {
        // Clean up the callback when the script is destroyed
        toggleAction.action.performed -= TogglePosition;
    }
}
