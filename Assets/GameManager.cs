using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject InventoryUI;
    public bool isPaused = false;
    public AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && isPaused == false){
            am.Play("Select");
            isPaused = true;
            pause.SetActive(true);
            InventoryUI.SetActive(true);
        }else if (Input.GetKeyDown(KeyCode.I) && isPaused == true){
            isPaused = false;
            pause.SetActive(false);
            InventoryUI.SetActive(false);
        }
    }
}
