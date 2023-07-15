using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool isPaused;
    private bool hasEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !hasEnded)
        {
            TogglePause();
        }    
    }

    void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
           // AudioListener.pause = true;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            // AudioListener.pause = false;
        }
    }

    //REFACUT CODUL
    public void playerDied()
    {
        hasEnded= true;
        Time.timeScale = 0;
    }

    public void YES()
    {
        Debug.Log("DA");
    }
}
