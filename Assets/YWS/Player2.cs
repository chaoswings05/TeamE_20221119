using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : SingletonMonoBehaviour<Player2>
{
    public List<Words> holdingWords = new List<Words>();
    public int score = 0;
    [SerializeField] private Text cursor = null;
    public int watchingNum = 0;
    public int cursorPosition = 0;
    public bool IsWordSelect = false;
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
        if (GameDirector.Instance.gameState == GameDirector.GameState.player2Active && !StateReady)
        {
            IsWordSelect = true;
            Map1.Instance.FindStartPoint();
            StateReady = true;
        }

        if (GameDirector.Instance.gameState == GameDirector.GameState.player1Active)
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
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

        if (Input.GetKeyDown(KeyCode.UpArrow))
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

        if (GameDirector.Instance.gameState == GameDirector.GameState.player2Active && Input.GetKeyDown(KeyCode.Slash))
        {
            IsWordSelect = false;
            IsPlateSelect = true;
            GameDirector.Instance.watchingPlate.IsWatchingThis = true;
        }
    }

    private void PlateSelect()
    {
        searchDistance = 1;
        if (GameDirector.Instance.watchingPointX > 0 && Input.GetKeyDown(KeyCode.UpArrow))
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
        
        if (GameDirector.Instance.watchingPointX < 4 && Input.GetKeyDown(KeyCode.DownArrow))
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
        

        if (GameDirector.Instance.watchingPointZ > 0 && Input.GetKeyDown(KeyCode.LeftArrow))
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

        if (GameDirector.Instance.watchingPointZ < 8 && Input.GetKeyDown(KeyCode.RightArrow))
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

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            holdingWords[watchingNum].transform.SetParent(GameDirector.Instance.watchingPlate.transform);
            holdingWords[watchingNum].transform.localPosition = Vector3.zero;
            Map1.Instance.map[GameDirector.Instance.watchingPointX, GameDirector.Instance.watchingPointZ] = holdingWords[watchingNum].wordValue;
            holdingWords.Remove(holdingWords[watchingNum]);
            GameDirector.Instance.gameState = GameDirector.GameState.judge;
            GameDirector.Instance.nextPlayer = 1;
            Timer.Instance.TimerReset();
            IsPlateSelect = false;
        }
    }
}
