using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceMove : MonoBehaviour
{
    private Vector3 firstPosition;


    void Start()
    {
        firstPosition = transform.position;
    }


    void OnMouseDrag()
    {

            Debug.Log("掴んだ"); //動作確認　済

            Vector3 thisPosition = Input.mousePosition;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
            worldPosition.z = 0f;

            this.transform.position = worldPosition;
        
    }

    void OnMouseUp()
    {
        Debug.Log("離した。");　// 動作確認　済
        this.transform.position = firstPosition;
    }

    void OnMouseUpAsButton()//オブジェクト上で左ボタンをアップした時だけ呼ばれる。
    {
        //if ()
       // {
            //なんらかの処理でマウスのボタンをアップしたときにマップのはまる位置だったらはまってそこに固定されるようにする？
       // }
    }

}


