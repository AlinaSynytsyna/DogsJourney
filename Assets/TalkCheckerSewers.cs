using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCheckerSewers : MonoBehaviour
{
    public NodeVisitedTracker Tracker;
    public Tutorial RedTutorial;
    public InteractNPC Interact;
    public Tutorial ChangeTutorial;
    private bool IsTalked;
    public void Awake()
    {
        RedTutorial.gameObject.SetActive(false);
        ChangeTutorial.gameObject.SetActive(false);
        IsTalked = false;
    }
    public void Update()
    {
        if (!IsTalked && Tracker._visitedNodes.Contains("Red.HelpMe"))
        {
            Interact.gameObject.SetActive(false);
            RedTutorial.gameObject.SetActive(true);
            ChangeTutorial.gameObject.SetActive(true);
            IsTalked = true;
        }
    }
}
