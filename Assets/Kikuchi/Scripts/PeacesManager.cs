using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacesManager : MonoBehaviour
{

    public GameObject group1Pieces;
    public GameObject group2Pieces;
    [SerializeField] private float upMoveRange = 7.0f;

    void Start() 
    {
        group2Pieces.SetActive(false);
    }

    public void DownSideButton()
    {
        Vector3 pos = this.transform.position;
        pos.y += upMoveRange; //移動の座標をRectTransformにして値を調整する。
        this.transform.position = pos;
        group2Pieces.SetActive(true);
        group1Pieces.SetActive(false);

    }
}
