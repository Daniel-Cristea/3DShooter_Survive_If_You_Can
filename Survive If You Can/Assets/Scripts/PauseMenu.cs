using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseGameMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !EndGameMenu.gameIsPaused)
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && EndGameMenu.gameIsPaused && !TargetPlayer.playerDied)
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {

        PauseGameMenuUI.SetActive(true);
        UnlockCursor();
        Time.timeScale = 0.0f;
        // AudioListener.pause = false;
        StartCoroutine(WaitForRealSeconds(0.1f));
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        // AudioListener.pause = false;
        EndGameMenu.gameIsPaused = false;
        PauseGameMenuUI.SetActive(false);
        LockCursor();
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
        EndGameMenu.gameIsPaused = true;

    }

}
