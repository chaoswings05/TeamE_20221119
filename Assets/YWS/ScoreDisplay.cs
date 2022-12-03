using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text P1ScoreDisplay = null;
    [SerializeField] private Text P2ScoreDisplay = null;

    // Update is called once per frame
    void Update()
    {
        P1ScoreDisplay.text = Player1.Instance.score.ToString() + " 枚";
        P2ScoreDisplay.text = Player2.Instance.score.ToString() + " 枚";
    }
}
