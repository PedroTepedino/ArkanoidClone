using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject panel;
    
    private bool isPaused = false;

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (GameManager.lost)
        {
            Time.timeScale = 0f;
            lostPanel.SetActive(true);
            return;
        }

        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (isPaused)
        { 
            Unpause();  
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        panel.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        isPaused = false;
        panel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}