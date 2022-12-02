using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
      if (Input.GetKey(KeyCode.Return))    // エンターキーを押したら
    {
        SceneManager.LoadScene("ResultScene");    // GameSceneに移動
    }
}
    public void changeScene()
{
    //現在のシーンの名前を取得
    string sceneName = SceneManager.GetActiveScene().name;
 
    if (sceneName == "TitleScene")
    {
        SceneManager.LoadScene("MainScene");
    }
}
}
