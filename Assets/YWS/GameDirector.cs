using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : SingletonMonoBehaviour<GameDirector>
{
    [SerializeField, Header("タイマー")] private Timer timer = null;

    public enum GameState
    {
        none,
        standby,
        player1Active,
        player2Active,
        judge,
        ended,
    }

    public GameState gameState = GameState.none;
    public int nextPlayer = 1;
    public Plate watchingPlate = null;
    public int watchingPointX = 0;
    public int watchingPointZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.standby;
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.standby:
                Map1.Instance.GenMap();
                gameState = GameState.player1Active;
                break;

            case GameState.player1Active:
                timer.IsCountDownStart = true;
                break;

            case GameState.player2Active:
                timer.IsCountDownStart = true;
                break;
            
            case GameState.judge:
                if (Player1.Instance.score >= Map1.Instance.targetScore)
                {
                    Debug.Log("Player1 Win");
                    gameState = GameState.ended;
                }
                else if (Player2.Instance.score >= Map1.Instance.targetScore)
                {
                    Debug.Log("Player2 Win");
                    gameState = GameState.ended;
                }
                else
                {
                    if (nextPlayer == 1)
                    {
                        gameState = GameState.player1Active;
                    }
                    else if (nextPlayer == 2)
                    {
                        gameState = GameState.player2Active;
                    }
                    else
                    {
                        Debug.LogError("Turn Change Error");
                    }
                }
                break;
        }
    }
}
