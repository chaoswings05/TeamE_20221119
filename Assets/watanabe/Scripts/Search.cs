using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour
{
    [SerializeField]
    private MapGen mapGen;
    [SerializeField]
    private MapSetting mapSetting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MojiSearch(GameObject obj)
    {
        /*
        ここで置いた文字を取る
        */
        var mStats = obj.GetComponent<MojiStats>();
        if(!mStats.Placeable) return;
        obj.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("X" + (mStats.x_pos + 1));
        Debug.Log("Y" + (mStats.y_pos + 1));
        int pos = (mStats.x_pos + 1) * (mStats.y_pos + 1);
        Debug.Log("***StatsPos " + mStats.num_count);
        var x_1 = mapGen.setList[mStats.num_count + 1];
        var y_1 = mapGen.setList[mStats.num_count + MapSetting.map_x];
        var DebugX = x_1.GetComponent<MojiStats>();
        var DebugY = y_1.GetComponent<MojiStats>();
        Debug.Log("DEBUGXX"+DebugX.x_pos);
        Debug.Log("DEBUGXY"+DebugX.y_pos);
        Debug.Log("DEBUGYX"+DebugY.x_pos);
        Debug.Log("DEBUGYY"+DebugY.y_pos);
        
    }
}
