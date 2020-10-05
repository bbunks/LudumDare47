using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public HUDController HUD;
    public static StageController Instance;
    public bool doubleJump = false, dash = false, roll = false, walljump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("HUD").GetComponent<HUDController>().isTimeUp()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
