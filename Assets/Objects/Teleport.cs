using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public enum TeleportState { InsideLevel, NextLevel, PreviousLevel, MainMenu }
    public TeleportState State;
    public bool IsCharacterHere;
    public float TeleportPositionX;
    public float TeleportPositionY;
    private SpriteRenderer Renderer;
    public void Awake()
    {
        Renderer = GetComponentInChildren<SpriteRenderer>();
        Renderer.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D Entity)
    {
        if (Entity.tag == "Player")
        {
            Renderer.gameObject.SetActive(true);
            IsCharacterHere = true;
        }

    }
    public void OnTriggerExit2D(Collider2D Entity)
    {
        if (Entity.tag == "Player")
        {
            Renderer.gameObject.SetActive(false);
            IsCharacterHere = false;
        }
    }
    public void TeleportPlayer(Player Player, PlayerCamera playerCamera)
    {
        if(State == TeleportState.InsideLevel)
            StartCoroutine(Teleportation(2, Player, playerCamera));
        if (State == TeleportState.NextLevel)
            StartCoroutine(NextLevel(2, playerCamera));
        if (State == TeleportState.PreviousLevel)
            StartCoroutine(PreviousLevel(2, playerCamera));
        if(State == TeleportState.MainMenu)
            StartCoroutine(MainMenu(2, playerCamera));
    }
    protected void StartTeleport(PlayerCamera playerCamera)
    {
        playerCamera.ScreenFader.fromInDelay = 0;
        playerCamera.ScreenFader.fromOutDelay = 0;
        playerCamera.ScreenFader.fadeSpeed = 3;
        playerCamera.ScreenFader.fadeState = ScreenFader.FadeState.In;
    }
    protected void EndTeleport(PlayerCamera playerCamera)
    {
        playerCamera.ScreenFader.fromInDelay = 0;
        playerCamera.ScreenFader.fromOutDelay = 0;
        playerCamera.ScreenFader.fadeSpeed = 3;
        playerCamera.ScreenFader.fadeState = ScreenFader.FadeState.Out;
    }
    protected IEnumerator Teleportation(float Delay, Player player, PlayerCamera playerCamera)
    {
        StartTeleport(playerCamera);
        yield return new WaitForSeconds(Delay);
        player.transform.position = new Vector3(TeleportPositionX, TeleportPositionY, player.transform.position.z);
        yield return new WaitForSeconds(Delay);
        EndTeleport(playerCamera);
    }
    protected IEnumerator NextLevel(float Delay, PlayerCamera playerCamera)
    {
        StartTeleport(playerCamera);
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    protected IEnumerator PreviousLevel(float Delay, PlayerCamera playerCamera)
    {
        StartTeleport(playerCamera);
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    protected IEnumerator MainMenu(float Delay, PlayerCamera playerCamera)
    {
        StartTeleport(playerCamera);
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene("MainMenu");
    }
}
