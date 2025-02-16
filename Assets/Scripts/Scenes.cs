using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    public void SwitchToTargetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void QuitGame()
    {
        //Application.Quit();
        //Dev mode
        SwitchToTargetScene("MainMenu");
    }
}
