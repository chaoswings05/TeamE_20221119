using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetting : MonoBehaviour
{
    public const int map_x = 11;   // 横マップサイズ
    public const int map_y = 11;   // 縦マップサイズ
    public int[,] map1 =  new int[map_x,map_y]   // マップ生成
    {                                                  // 0で配置可能
        {1,1,1,1,1,1,1,1,1,1,1},                       // 1で配置不可能
        {1,1,0,0,1,1,1,0,0,1,1},
        {1,0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,1,1,1,0,0,0,1},
        {1,0,0,0,1,1,1,0,0,0,1},
        {1,0,0,0,1,1,1,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,1},
        {1,1,0,0,1,1,1,0,0,1,1},
        {1,1,1,1,1,1,1,1,1,1,1},
    };
}
