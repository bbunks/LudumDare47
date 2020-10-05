using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserCollisions : MonoBehaviour
{

     public PlayerCollision collisions;

    // Start is called before the first frame update
    void Start()
    {
        collisions = GetComponent<PlayerCollision>(); 
    }

    // Update is called once per frame
    void Update()
    {
         for(int i=0; i < collisions.getCollisions().Length; i++) {
            if(collisions.getCollisions()[i] != null) {
                if(collisions.getCollisions()[i].tag == "Laser" || collisions.getCollisions()[i].name == "Abyss") {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
