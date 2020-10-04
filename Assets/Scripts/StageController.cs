using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public HUDController HUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUD.isTimeUp()) {
            Debug.Log("Timer is up bro!");
        }
    }
}
