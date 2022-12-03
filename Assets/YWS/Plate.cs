using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    [SerializeField] private Image plate = null;
    public bool IsThisPlateUse = true;
    public bool IsWatchingThis = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWatchingThis)
        {
            plate.color = new Color(1,1,1,0.5f);
        }
        else if (!IsWatchingThis && IsThisPlateUse)
        {
            plate.color = new Color(1,1,1,1);
        }
    }
}
