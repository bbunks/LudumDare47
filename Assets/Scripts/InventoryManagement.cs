using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public PlayerCollision collisions;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] currentCollisions = GameObject.Find("Player").GetComponent<PlayerCollision>().getCollisions();
        if (currentCollisions != null) {
            for (int i = 0; i < currentCollisions.Length; i++)
            {
                if (currentCollisions[i] != null)
                {
                    if (currentCollisions[i].tag == "collectible")
                    {
                        switch (currentCollisions[i].name)
                        {
                            case "gfx_doublejump":
                                Destroy(GameObject.Find(currentCollisions[i].name));
                                StageController.Instance.doubleJump = true;
                                break;
                            case "gfx_dash":
                                Destroy(GameObject.Find(currentCollisions[i].name));
                                StageController.Instance.dash = true;
                                break;
                            case "gfx_roll":
                                Destroy(GameObject.Find(currentCollisions[i].name));
                                StageController.Instance.roll = true;
                                break;
                            case "gfx_walljump":
                                Destroy(GameObject.Find(currentCollisions[i].name));
                                StageController.Instance.walljump = true;
                                break;
                            default:
                                Debug.Log("Not a known collectible");
                                break;
                        }
                    }
                }
            }
        }
    }
}
