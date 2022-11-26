using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceMove : MonoBehaviour
{
    void OnMouseDrag()
    {

            Debug.Log("つかんでる");
            //マウスの座標を取得してスクリーン座標を更新
            Vector3 thisPosition = Input.mousePosition;
            //スクリーン座標→ワールド座標
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
            worldPosition.z = 0f;

            this.transform.position = worldPosition;
        
    }
}


