using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public enum GameState
    {
        none,
        standby,
        player1Active,
        player2Active,
        judge,
        end,
        ended,
    }

    public GameState gameState = GameState.none;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.player1Active:
                break;

            case GameState.player2Active:
                break;
            
            case GameState.judge:
                break;

            case GameState.end:
                break;

            case GameState.ended:
                break;
        }
    }
}
