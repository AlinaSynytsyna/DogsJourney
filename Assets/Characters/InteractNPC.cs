using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Characters;

public class InteractNPC : MonoBehaviour
{
    private NPC Self;
    private Player Player;
    private CircleCollider2D Trigger;
    private SpriteRenderer Renderer;
    public void Awake()
    {
        Trigger = GetComponent<CircleCollider2D>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        Self = GetComponentInParent<NPC>();
        if(Self == null)
            Self = GetComponent<NPC>();
        Renderer.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D Entity)
    {
        if (Entity.tag == "Player" && !string.IsNullOrEmpty(Self.talkToNode))
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
