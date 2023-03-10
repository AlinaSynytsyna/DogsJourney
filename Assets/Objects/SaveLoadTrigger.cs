using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadTrigger : MonoBehaviour
{
    public SaveLoadSystem SaveLoadSystem;
    private Player Player;
    private CircleCollider2D Trigger;
    private SpriteRenderer Renderer;
    public void Awake()
    {
        Trigger = GetComponent<CircleCollider2D>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        Renderer.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D Entity)
    {
        if (Entity.tag == "Player")
        {
            var allParticipants = new List<Player>(FindObjectsOfType<Player>());
            Player = allParticipants.Find(delegate (Player P) {
                return ((P.transform.position - this.transform.position)
                .magnitude <= Trigger.radius * 10 && P.IsActive);
            });
            if (Player != null)
            {
                Renderer.gameObject.SetActive(true);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D Entity)
    {
        if (Entity.tag == "Player")
        {
            Player = null;
            Renderer.gameObject.SetActive(false);
        }
    }

}
