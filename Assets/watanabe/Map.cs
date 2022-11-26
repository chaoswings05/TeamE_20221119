using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map :MonoBehaviour
{
    //ステージの大きさ
    private const int width = 10;
    private const int height = 10;

    //マップ
    public string[,] map = new string[height, width] // z, x座標で指定
    {
        {"□", "□", "□", "□", "□", "□", "□", "□", "□", "□"},
        {"□", "□", "□", "□", "0", "0", "□", "□", "□", "□"},
        {"□", "□", "0", "0", "0", "0", "0", "0", "□", "□"},
        {"□", "0", "0", "0", "0", "0", "0", "0", "0", "□"},
        {"□", "0", "0", "0", "0", "0", "0", "0", "0", "□"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"□", "0", "0", "0", "□", "□", "0", "0", "0", "□"},
        {"□", "□", "0", "0", "□", "□", "0", "0", "□", "□"}
    };
    //文字をおけるところ
    public readonly string empty = "0";
    //おけない所
    public readonly string Wall = "□";
    public readonly string character = "1";

    public bool CheckMap()
    {
        int x = 100;
        int y = 100;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[j, i] == character)
                {
                    //配置不可能なマス配置

                }
                else
                {
                    //配置可能なマス配置

                }
                x -= 10;
            }
            y -= 10;
        }
        return true;
    } 
}