using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : SingletonMonoBehaviour<Player1>
{
    public List<Words> holdingWords = new List<Words>();
    public int score = 0;
    [SerializeField] private Text cursor = null;
    public int watchingNum = 0;
    public int cursorPosition = 0;
    public bool IsWordSelect = true;
    public bool IsPlateSelect = false;
    private bool StateReady = false;
    private int searchDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameDirector.Instance.gameState == GameDirector.GameState.player1Active && !StateReady)
        {
            IsWordSelect = true;
            Map1.Instance.FindStartPoint();
            StateReady = true;
        }

        if (GameDirector.Instance.gameState == GameDirector.GameState.player2Active)
        {
            StateReady = false;
        }

        if (IsWordSelect)
        {
            WordSelect();
        }

        if (IsPlateSelect)
        {
            PlateSelect();
        }
    }

    private void WordSelect()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (cursorPosition < 8)
            {
                cursorPosition++;
                cursor.transform.localPosition -= new Vector3(0,100,0);
            }
            else
            {
                holdingWords[watchingNum-cursorPosition].gameObject.SetActive(false);
            }

            if (watchingNum < holdingWords.Count-2)
            {
                watchingNum++;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (cursorPosition > 0)
            {
                cursorPosition--;
                cursor.transform.localPosition += new Vector3(0,100,0);
            }
            else
            {
                holdingWords[watchingNum].gameObject.SetActive(true);
            }

            if (watchingNum > 0)
            {
                watchingNum--;
            }
        }

        if (GameDirector.Instance.gameState == GameDirector.GameState.player1Active && Input.GetKeyDown(KeyCode.Q))
        {
            IsWordSelect = false;
            IsPlateSelect = true;
            GameDirector.Instance.watchingPlate.IsWatchingThis = true;
        }
    }

    private void PlateSelect()
    {
        searchDistance = 1;
        if (GameDirector.Instance.watchingPointX > 0 && Input.GetKeyDown(KeyCode.W))
        {
            while (true)
            {
                if (Map1.Instance.CheckEmpty(GameDirector.Instance.watchingPointX - searchDistance, GameDirector.Instance.watchingPointZ))
                {
                    GameDirector.Instance.watchingPlate.IsWatchingThis = false;
                    GameDirector.Instance.watchingPointX -= searchDistance;
                    GameDirector.Instance.watchingPlate = Map1.Instance.plateMap[GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ];
                    GameDirector.Instance.watchingPlate.IsWatchingThis = true;
                    break;
                }
                else if (!Map1.Instance.CheckIsAble(GameDirector.Instance.watchingPointX - searchDistance, GameDirector.Instance.watchingPointZ))
                {
                    break;
                }
                else if (Map1.Instance.CheckIsWord(GameDirector.Instance.watchingPointX - searchDistance, GameDirector.Instance.watchingPointZ))
                {
                    if (GameDirector.Instance.watchingPointX - searchDistance <= 0)
                    {
                        break;
                    }
                    else
                    {
                        searchDistance++;
                    }
                }
            }
        }
        
        if (GameDirector.Instance.watchingPointX < 4 && Input.GetKeyDown(KeyCode.S))
        {
            while (true)
            {
                if (Map1.Instance.CheckEmpty(GameDirector.Instance.watchingPointX + searchDistance, GameDirector.Instance.watchingPointZ))
                {
                    GameDirector.Instance.watchingPlate.IsWatchingThis = false;
                    GameDirector.Instance.watchingPointX += searchDistance;
                    GameDirector.Instance.watchingPlate = Map1.Instance.plateMap[GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ];
                    GameDirector.Instance.watchingPlate.IsWatchingThis = true;
                    break;
                }
                else if (!Map1.Instance.CheckIsAble(GameDirector.Instance.watchingPointX + searchDistance, GameDirector.Instance.watchingPointZ))
                {
                    break;
                }
                else if (Map1.Instance.CheckIsWord(GameDirector.Instance.watchingPointX + searchDistance, GameDirector.Instance.watchingPointZ))
                {
                    if (GameDirector.Instance.watchingPointX + searchDistance >= 4)
                    {
                        break;
                    }
                    else
                    {
                        searchDistance++;
                    }
                }
            }
        }
        

        if (GameDirector.Instance.watchingPointZ > 0 && Input.GetKeyDown(KeyCode.A))
        {
            while (true)
            {
                if (Map1.Instance.CheckEmpty(GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ - searchDistance))
                {
                    GameDirector.Instance.watchingPlate.IsWatchingThis = false;
                    GameDirector.Instance.watchingPointZ -= searchDistance;
                    GameDirector.Instance.watchingPlate = Map1.Instance.plateMap[GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ];
                    GameDirector.Instance.watchingPlate.IsWatchingThis = true;
                    break;
                }
                else if (!Map1.Instance.CheckIsAble(GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ - searchDistance))
                {
                    break;
                }
                else if (Map1.Instance.CheckIsWord(GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ - searchDistance))
                {
                    if (GameDirector.Instance.watchingPointZ - searchDistance <= 0)
                    {
                        break;
                    }
                    else
                    {
                        searchDistance++;
                    }
                }
            }
        }

        if (GameDirector.Instance.watchingPointZ < 8 && Input.GetKeyDown(KeyCode.D))
        {
            while (true)
            {
                if (Map1.Instance.CheckEmpty(GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ + searchDistance))
                {
                    GameDirector.Instance.watchingPlate.IsWatchingThis = false;
                    GameDirector.Instance.watchingPointZ += searchDistance;
                    GameDirector.Instance.watchingPlate = Map1.Instance.plateMap[GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ];
                    GameDirector.Instance.watchingPlate.IsWatchingThis = true;
                    break;
                }
                else if (!Map1.Instance.CheckIsAble(GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ + searchDistance))
                {
                    break;
                }
                else if (Map1.Instance.CheckIsWord(GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ + searchDistance))
                {
                    if (GameDirector.Instance.watchingPointZ + searchDistance >= 8)
                    {
                        break;
                    }
                    else
                    {
                        searchDistance++;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            holdingWords[watchingNum].transform.SetParent(GameDirector.Instance.watchingPlate.transform);
            holdingWords[watchingNum].transform.localPosition = Vector3.zero;
            Map1.Instance.map[GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ] = holdingWords[watchingNum].wordValue;
            holdingWords.Remove(holdingWords[watchingNum]);
            GameDirector.Instance.gameState = GameDirector.GameState.judge;
            GameDirector.Instance.nextPlayer = 2;
            Timer.Instance.TimerReset();
            IsPlateSelect = false;
            IsWordSelect = true;
        }
    }
}
