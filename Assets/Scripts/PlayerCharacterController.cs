using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    [SerializeField] GameManager game_manager;
   private void OnPause(InputValue value) 
   {
        if (value.isPressed)
        {
            game_manager.Pause();
        }
   }

    private void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            GetComponent<Inventory>().RemoveItem();
        }
    }

    private void OnToggleInventory(InputValue value)
    {
        if (value.isPressed)
        {
            game_manager.ToggleInventory();
        }
    }
}
