using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Canvas hud;
    public InventoryManagement inventory;

    public float timer = 40;

    public Component[] childText;

    private GameObject doubleJumpIcon, dashIcon, rollIcon, wallJumpIcon, CollectedText;
    // Start is called before the first frame update
    void Start()
    {
        childText = GetComponentsInChildren<Text>();
        doubleJumpIcon = GameObject.Find("doublejumpIcon");
        dashIcon = GameObject.Find("dashIcon");
        rollIcon = GameObject.Find("rollIcon");
        wallJumpIcon = GameObject.Find("walljumpIcon");
    }

    // Update is called once per frame
    void Update()
    {
        
        childText[0].GetComponent<Text>().text = DisplayTime(timer);
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        doubleJumpIcon.SetActive(inventory.doubleJump);
        dashIcon.SetActive(inventory.dash);
        rollIcon.SetActive(inventory.roll);
        wallJumpIcon.SetActive(inventory.walljump);

        if(inventory.doubleJump) {
            childText[1].GetComponent<Text>().text = "You now have the Double Jump. Press the Jump button in mid-air";
        }
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
