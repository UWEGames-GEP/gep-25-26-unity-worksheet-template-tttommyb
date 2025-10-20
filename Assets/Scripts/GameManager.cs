using UnityEngine;



public class GameManager : MonoBehaviour
{
    enum GameState  { GAMEPLAY, PAUSE};
    [SerializeField] GameState state;
    bool hasChangedState  = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hasChangedState = true;

            switch (state)
            {
                case GameState.GAMEPLAY:
                    state = GameState.PAUSE;
                    break;
                case GameState.PAUSE:
                    state = GameState.GAMEPLAY;
                    break;
            }
        }
       
        
    }

    private void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;

            switch (state)
            {
                case GameState.GAMEPLAY:
                    Time.timeScale = 1.0f;
                    break;
                case GameState.PAUSE:
                    Time.timeScale = 0.0f;
                    break;
            }
        }
    }

    public int getState() 
    {
        return (int)state;
    }
}
