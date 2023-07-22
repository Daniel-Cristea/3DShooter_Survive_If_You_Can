using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] private GameObject EndGameMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(TargetPlayer.playerDied)
        {
            EndGame();
        }
    }

    public void RestartGame()
    {
        TargetPlayer.playerDied = false;
        EndGameMenu.gameIsPaused = false;
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        EndGameMenuUI.SetActive(false);
        SceneManager.LoadScene("Main_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void EndGame()
    {
        UnlockCursor();
        EndGameMenuUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
