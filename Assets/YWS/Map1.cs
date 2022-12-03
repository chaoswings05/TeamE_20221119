using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Map1 : SingletonMonoBehaviour<Map1>
{
    private const int width = 9;
    private const int height = 5;

    public string[,] map = new string[height, width]
    {
        {"x", "x", "x", "x", "□", "□", "●", "□", "□"},
        {"x", "x", "x", "□", "□", "●", "□", "□", "x"},
        {"x", "x", "□", "□", "●", "□", "□", "x", "x"},
        {"x", "□", "□", "●", "□", "□", "x", "x", "x"},
        {"□", "□", "●", "□", "□", "x", "x", "x", "x"}
    };

    public Plate[,] plateMap = new Plate[height, width];

    public readonly string empty = "□";
    public readonly string filled = "●";
    public readonly string noUse = "x";
    public int targetScore = 13;
    [SerializeField] private GameObject platePrefab = null;
    [SerializeField] private GameObject wordPrefab = null;
    private string[] wordArray = new string[71] 
    {"あ","い","う","え","お",
     "か","き","く","け","こ",
     "が","ぎ","ぐ","げ","ご",
     "さ","し","す","せ","そ",
     "ざ","じ","ず","ぜ","ぞ",
     "た","ち","つ","て","と",
     "だ","ぢ","づ","で","ど",
     "な","に","ぬ","ね","の",
     "は","ひ","ふ","へ","ほ",
     "ば","び","ぶ","べ","ぼ",
     "ぱ","ぴ","ぷ","ぺ","ぽ",
     "ま","み","む","め","も",
     "や",     "ゆ",     "よ",
     "ら","り","る","れ","ろ",
     "わ",     "を",     "ん"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenMap()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject newPlate = Instantiate(platePrefab);
                newPlate.transform.SetParent(this.transform);
                newPlate.transform.localScale = Vector3.one;
                Plate plate = newPlate.GetComponent<Plate>();
                plateMap[i,j] = plate;
                if (map[i,j] == noUse)
                {
                    plate.IsThisPlateUse = false;
                    plate.GetComponent<Image>().color = Color.clear;
                }
                else if (map[i,j] == filled)
                {
                    GameObject newWord = Instantiate(wordPrefab);
                    newWord.transform.SetParent(plateMap[i,j].transform);
                    newWord.transform.localPosition = Vector3.zero;
                    Words word = newWord.GetComponent<Words>();
                    int wordNum = Random.Range(0,wordArray.Length);
                    word.SetDisplayWord(wordArray[wordNum]);
                    map[i,j] = wordArray[wordNum];
                }
            }
        }
    }

    public void FindStartPoint()
    {
        bool IsNewStartPointFind = false;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (map[i,j] == empty)
                {
                    GameDirector.Instance.watchingPointX = i;
                    GameDirector.Instance.watchingPointZ = j;
                    GameDirector.Instance.watchingPlate = plateMap[i,j];
                    IsNewStartPointFind = true;
                    break;
                }
            }
            if (IsNewStartPointFind)
            {
                break;
            }
        }
    }

    public bool CheckEmpty(int x, int z)
    {
        if (map[x,z] == empty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIsAble(int x, int z)
    {
        if (map[x,z] == noUse)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool CheckIsWord(int x, int z)
    {
        if (map[x,z] == empty || map[x,z] == filled || map[x,z] == noUse)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void CheckIsWordComplete()
    {
        
    }
}