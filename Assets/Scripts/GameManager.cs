using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;



public class GameManager : MonoBehaviour
{
    private State gameplay_state, pause_state, inventory_state;
    [SerializeField] private State state;
    private bool hasChangedState = false;
    [SerializeField] private GameObject inventory_ui;
    [SerializeField] private GameObject pause_ui;
    private GameObject current_ui;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameplay_state = new State(1.0f, "Gameplay", CursorLockMode.Locked);
        pause_state = new State(0.0f, "Pause", CursorLockMode.None, pause_ui);
        inventory_state = new State(0.0f, "Inventory", CursorLockMode.None, inventory_ui);
        state = gameplay_state;
    }
    
    private void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;

            Time.timeScale = state.getTimeScale();
            Cursor.lockState = state.getCursorLockMode();
            Debug.Log(current_ui != null);
            if (state.getHasUi())
            {
                state.getUIPanel().SetActive(true);
               
            }
            if (current_ui != null)
            {
                current_ui.SetActive(false);
            }
            current_ui = state.getUIPanel();
        
        }
    }

    public State GetState() 
    {
        return state;
    }

    public void Pause() 
    {
        hasChangedState = true;

        switch (state.getStateName())
        {
            case "Gameplay":
                state = pause_state;
                break;
            case "Inventory":
                state = pause_state;
                break;
            case "Pause":
                state = gameplay_state;
                break;
        }
    }

    public void ToggleInventory()
    {
        hasChangedState = true;

        switch (state.getStateName())
        {
            case "Gameplay":
                state = inventory_state;
                break;
            case "Inventory":
                state = gameplay_state;
                break;
            case "Pause":
                hasChangedState = false;
                break;
        }

    }
}
