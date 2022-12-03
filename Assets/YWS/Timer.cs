using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : SingletonMonoBehaviour<Timer>
{
    [SerializeField, Header("表示テキスト")] private Text displayText = null;
    [SerializeField, Header("1ターンの制限時間")] private float timeLimit = 45f;
    private float elapsedTime = 0f;
    public bool IsCountDownStart = false;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = Mathf.Floor(elapsedTime).ToString();

        if (IsCountDownStart)
        {
            elapsedTime -= Time.deltaTime;
        }

        if (elapsedTime <= 0)
        {
            Debug.Log("Auto Pass");
            IsCountDownStart = false;
            if (GameDirector.Instance.gameState == GameDirector.GameState.player1Active)
            {
                GameDirector.Instance.gameState = GameDirector.GameState.player2Active;
            }
            else if (GameDirector.Instance.gameState == GameDirector.GameState.player2Active)
            {
                GameDirector.Instance.gameState = GameDirector.GameState.player1Active;
            }
            TimerReset();
        }
    }

    public void TimerReset()
    {
        displayText.text = timeLimit.ToString();
        elapsedTime = timeLimit;
    }
}
