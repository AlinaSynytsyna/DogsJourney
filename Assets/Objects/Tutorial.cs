using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    public enum TutorialType { Moving, Interaction, SpecialAbility, Healing, Change, Save }
    public TutorialType State;
    private Player Player;
    public CustomInput Input;
    private Text TutorialText;
    private CircleCollider2D Trigger;
    private Canvas TutorialCanvas;
    public void Awake()
    {
        TutorialCanvas  = GetComponentInChildren<Canvas>();
        TutorialText = GetComponentInChildren<Text>();
        Trigger = GetComponent<CircleCollider2D>();
        TutorialCanvas.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D Entity)
    {

        if (Entity.tag == "Player")
        {
            var allParticipants = new List<Player>(FindObjectsOfType<Player>());
            Player = allParticipants.Find(delegate (Player P) {
                return ((P.transform.position - transform.position)
                .magnitude <= Trigger.radius * 10 && P.IsActive);
            });
            if (Player != null)
            {
                TutorialCanvas.worldCamera = Player.PlayerCamera.Camera;
                TutorialCanvas.gameObject.SetActive(true);
                CheckText();
            }
        }
    }
    public void OnTriggerExit2D(Collider2D Entity)
    {
        if (Entity.tag == "Player")
        {
            TutorialCanvas.worldCamera = null;
            TutorialCanvas.gameObject.SetActive(false);
        }
    }
    public void CheckText()
    {
        if (State == TutorialType.Moving)
            TutorialText.text = $"Управление персонажем: \nВлево: {Input.Left}\nВправо: {Input.Right}\nПрыжок: {Input.Jump}";
        if (State == TutorialType.SpecialAbility && Player is Zima)
            TutorialText.text = $"Зима может перепрыгивать длинные расстояния по нажатию клавиши {Input.Special}";
        if (State == TutorialType.SpecialAbility && Player is Red)
            TutorialText.text = $"Рэд может совершать двойной прыжок по нажатию клавиши {Input.Special}";
        if (State == TutorialType.Interaction)
            TutorialText.text = $"Взаимодействовать с окружением возможно по нажатии клавиши {Input.Interact}";
        if (State == TutorialType.Healing)
            TutorialText.text = $"Пончик восстанавливает здоровье на 10 единиц";
        if (State == TutorialType.Change)
            TutorialText.text = $"Между персонажами можно переключаться по нажатию клавиши {Input.Change}";
        if (State == TutorialType.Save)
            TutorialText.text = $"Прогресс можно сохранять в специальных местах, отмеченных крестом";
    }
}
