using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;



public class GameManager : MonoBehaviour
{
    private State gameplay_state, pause_state;
    [SerializeField] private State state;
    private bool hasChangedState  = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameplay_state = new State(1.0f, "Gameplay");
        pause_state = new State(0.0f, "Pause");
        state = gameplay_state;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hasChangedState = true;

            switch (state.getStateName())
            {
                case "Gameplay":
                    state = pause_state;
                    break;
                case "Pause":
                    state = gameplay_state;
                    break;
            }
        }
       
        
    }

    private void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;

            Time.timeScale = state.getTimeScale();
            
        }
    }

    public State getState() 
    {
        return state;
    }
}
