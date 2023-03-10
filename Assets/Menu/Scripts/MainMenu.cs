using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text PlayButtonText;
    public SaveLoadSystem SaveLoadSystem;
    public MainCamera Camera;
    public Settings Settings;
    public SettingsValues Values;
    public void Awake()
    {
        Values.LoadSettings();
        if (SaveLoadSystem.HasInfo)
        {
            PlayButtonText.text = "Продолжить";
        }
        else
        {
            PlayButtonText.text = "Новая игра";
        }
    }
    public void Update()
    {
        if (SaveLoadSystem.HasInfo)
        {
            PlayButtonText.text = "Продолжить";
        }
        else
        {
            PlayButtonText.text = "Новая игра";
        }
    }
    public void PlayPressed()
    {
        Camera.EndCamera();
        Invoke("Play", 4F);
    }
    public void Play()
    {
        if (SaveLoadSystem.HasInfo)
        { 
                SceneManager.LoadScene(SaveLoadSystem.CurrentScene);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void ExitPressed()
    {
        Camera.EndCamera();
        Invoke("Exit", 4F);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        Settings.gameObject.SetActive(true);
        Settings.SetUpSettings();
        this.gameObject.SetActive(false);
    }
}