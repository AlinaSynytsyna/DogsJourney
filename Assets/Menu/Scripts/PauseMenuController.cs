using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public PlayerCamera Camera;
    public GameObject PauseMenu;
    public Player Player;
    private bool MenuIsSeen = false;
    void Awake()
    {
        PauseMenu.gameObject.SetActive(false);
        Player.enabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MenuIsSeen)
                GamePause();
            if(MenuIsSeen)
                Resume();
            MenuIsSeen = !MenuIsSeen;
        }
    }
   public void GamePause()
    {
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);
        Player.enabled = false;
    }
    public void Quit()
    {
        SaveLoadTrigger Save = FindObjectOfType<SaveLoadTrigger>();
        Save.SaveLoadSystem.SaveCurrentScene();
        foreach (Player Obj in GameObject.FindObjectsOfType<Player>())
            if (Obj.gameObject.activeInHierarchy)
                Save.SaveLoadSystem.SavePlayerInfo(Obj);
            Time.timeScale = 1;
        Camera.EndCamera();
        Invoke("QuitPressed", 4F);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        Player.enabled = true;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        Player.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitPressed()
    {
        Player.enabled = true;
        SceneManager.LoadScene("MainMenu");
    }
}
