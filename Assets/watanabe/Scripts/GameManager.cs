using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MapGen mapGen;
    [SerializeField]
    private Search search;
    // Start is called before the first frame update
    void Start()
    {
        mapGen.Mapgen();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var i = Random.Range(0,122);
            Debug.Log(i);
            search.MojiSearch(mapGen.setList[i]);
        }
    }

    /*
    置いた後の処理

    */
}
