using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    [SerializeField]
    public MapSetting mapSetting;
    [SerializeField]
    private List<GameObject> Squares = new List<GameObject>();
    public List<GameObject> setList = new List<GameObject>();

    private int Count;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mapgen()
    {
        var x = 100 * MapSetting.map_x;
        var y = 80 * MapSetting.map_y;
        for(int i = 0; MapSetting.map_y > i; i++)
        {
            for(int j = 0; MapSetting.map_x > j; j++)
            {
                
                var obj = Instantiate(Squares[mapSetting.map1[j,i]], new Vector3( x, y, 0f), Quaternion.identity);
                setList.Add(obj);
                var mStats = obj.GetComponent<MojiStats>();
                mStats.num_count = Count;
                mStats.x_pos = j;
                mStats.y_pos = i;
                if(mapSetting.map1[j,i] == 0) mStats.Placeable = true;
                else                          mStats.Placeable = false;
                x -= 20 * MapSetting.map_x;
                Count++;
            }
            x = 100 * MapSetting.map_x;
            y -= 16 * MapSetting.map_y;
        }
    }


}
