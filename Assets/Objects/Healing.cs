using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private Player Player;
    private CircleCollider2D Trigger;
    public void Awake()
    {
        Trigger = GetComponent<CircleCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D Entity)
    {
        if (Entity.tag == "Player")
        {
            var allParticipants = new List<Player>(FindObjectsOfType<Player>());
            Player = allParticipants.Find(delegate (Player P) {
                return ((P.transform.position - this.transform.position)
                .magnitude <= Trigger.radius * 3 && P.IsActive && P.Health < 100);
            });
            if (Player != null)
            {
                Player.Health += 10;
                if (Player.Health > 100)
                    Player.Health = 100;
                gameObject.SetActive(false);
            }
        }
    }

}
