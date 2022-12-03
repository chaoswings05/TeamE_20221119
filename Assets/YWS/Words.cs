using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Words : MonoBehaviour
{
    [SerializeField, Header("表示テキスト")] private Text displayText = null;
    public string wordValue = "";

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDisplayWord(string word)
    {
        displayText.text = word;
        wordValue = word;
    }
}
