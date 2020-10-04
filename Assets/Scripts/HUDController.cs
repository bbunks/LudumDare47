using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Canvas hud;
    public InventoryManagement inventory;

    public float timer = 60*2;

    public Text timerText;
    private GameObject doubleJumpIcon, dashIcon, rollIcon, wallJumpIcon;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        doubleJumpIcon = GameObject.Find("doublejumpIcon");
        dashIcon = GameObject.Find("dashIcon");
        rollIcon = GameObject.Find("rollIcon");
        wallJumpIcon = GameObject.Find("walljumpIcon");
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = DisplayTime(timer);
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        doubleJumpIcon.SetActive(inventory.doubleJump);
        dashIcon.SetActive(inventory.dash);
        rollIcon.SetActive(inventory.roll);
        wallJumpIcon.SetActive(inventory.walljump);
    }

    private string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public bool isTimeUp() {
        return timer <= 0;
    }
}
