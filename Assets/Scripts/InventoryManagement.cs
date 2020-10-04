using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public PlayerCollision collisions;
    public bool doubleJump = false, dash = false, roll = false, walljump = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < collisions.getCollisions().Length; i++) {
            if(collisions.getCollisions()[i] != null) {
                if(collisions.getCollisions()[i].tag == "collectible") {
                    switch(collisions.getCollisions()[i].name) {
                        case "doubleJump" :
                            Destroy(GameObject.Find(collisions.getCollisions()[i].name));
                            doubleJump = true;
                        break;
                        case "dash" :
                            Destroy(GameObject.Find(collisions.getCollisions()[i].name));
                            dash = true;
                        break;
                        case "roll" :
                            Destroy(GameObject.Find(collisions.getCollisions()[i].name));
                            roll = true;
                        break;
                        case "walljump" :
                            Destroy(GameObject.Find(collisions.getCollisions()[i].name));
                            walljump = true;
                        break;
                        default :
                            Debug.Log("Not a known collectible");
                        break;
                    }
                }
            }
        }
    }
}
