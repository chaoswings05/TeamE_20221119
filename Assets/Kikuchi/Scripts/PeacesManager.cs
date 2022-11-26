using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacesManager : MonoBehaviour
{
    [SerializeField] private float upMoveRange = 7.0f;
    public void DownSideButton()
    {
        Vector3 pos = this.transform.position;

        pos.y += upMoveRange; //移動の座標をRectTransformにして値を調整する。

        this.transform.position = pos;
    }
}
