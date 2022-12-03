using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    [SerializeField, Header("プレイヤー1の生成位置")] private Transform P1GenPoint = null;
    [SerializeField, Header("プレイヤー2の生成位置")] private Transform P2GenPoint = null;
    [SerializeField, Header("生成するプレハブ")] private GameObject wordPrefabs = null;
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
        for (int i = 0; i < wordArray.Length; i++)
        {
            GameObject genObj = Instantiate(wordPrefabs);
            genObj.transform.SetParent(P1GenPoint);
            Words newWord = genObj.GetComponent<Words>();
            newWord.SetDisplayWord(wordArray[i]);
            Player1.Instance.holdingWords.Add(newWord);
        }

        for (int i = 0; i < wordArray.Length; i++)
        {
            GameObject genObj = Instantiate(wordPrefabs);
            genObj.transform.SetParent(P2GenPoint);
            Words newWord = genObj.GetComponent<Words>();
            newWord.SetDisplayWord(wordArray[i]);
            Player2.Instance.holdingWords.Add(newWord);
        }
    }
}
