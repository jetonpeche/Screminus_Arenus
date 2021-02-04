using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();            
            }
            else 
            {
                Pause();  
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;

        Souris.DebloquerCurseur();
    }

    public void Resume()
    {
        Souris.BloquerCurseur();

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
}
