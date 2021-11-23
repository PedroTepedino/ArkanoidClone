using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene("Scenes/Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
