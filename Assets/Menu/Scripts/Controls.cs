using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{

    public SaveLoadSystem SaveLoadSystem;
    public Button SaveButton;
    [SerializeField] private Text Left;
    [SerializeField] private Text Right;
    [SerializeField] private Text Jump;
    [SerializeField] private Text Interact;
    [SerializeField] private Text Ability;
    [SerializeField] private Text Change;
    public CustomInput CurrentControls;
    private IEnumerator Coroutine;
    public void DeleteSave()
    {
        SaveLoadSystem.CleanAllData();
    }
    public void SetUpKeys()
    {
        if (CurrentControls.Left == KeyCode.None)
            CurrentControls.Left = KeyCode.A;
        if (CurrentControls.Right == KeyCode.None)
            CurrentControls.Right = KeyCode.D;
        if (CurrentControls.Jump == KeyCode.None)
            CurrentControls.Jump = KeyCode.Space;
        if (CurrentControls.Special == KeyCode.None)
            CurrentControls.Special = KeyCode.E;
        if (CurrentControls.Interact == KeyCode.None)
            CurrentControls.Interact = KeyCode.F;
        if (CurrentControls.Change == KeyCode.None)
            CurrentControls.Change = KeyCode.Q;
        RefreshKeys();
        Left.text = CurrentControls.Left.ToString();
        Right.text = CurrentControls.Right.ToString();
        Jump.text = CurrentControls.Jump.ToString();
        Interact.text = CurrentControls.Interact.ToString();
        Ability.text = CurrentControls.Special.ToString();
        Change.text = CurrentControls.Change.ToString();
    }
    public void Update()
    {
        if (SaveLoadSystem.HasInfo)
            SaveButton.interactable = true;
        else
            SaveButton.interactable = false;

    }
    public void RefreshKeys()
    {
        CurrentControls.KeyCodes.Clear();
        CurrentControls.KeyCodes.Add(CurrentControls.Left);
        CurrentControls.KeyCodes.Add(CurrentControls.Right);
        CurrentControls.KeyCodes.Add(CurrentControls.Jump);
        CurrentControls.KeyCodes.Add(CurrentControls.Special);
        CurrentControls.KeyCodes.Add(CurrentControls.Interact);
        CurrentControls.KeyCodes.Add(CurrentControls.Change);
    }
    public void SetLeftKey()
    {
        Left.text = "???";
        Coroutine = WaitLeft();
        StartCoroutine(Coroutine);
    }
    public void SetRightKey()
    {
        Right.text = "???";
        Coroutine = WaitRight();
        StartCoroutine(Coroutine);
    }
    public void SetJumpKey()
    {
        Jump.text = "???";
        Coroutine = WaitJump();
        StartCoroutine(Coroutine);
    }
    public void SetInteractKey()
    {
        Interact.text = "???";
        Coroutine = WaitInteract();
        StartCoroutine(Coroutine);
    }
    public void SetAbilityKey()
    {
        Ability.text = "???";
        Coroutine = WaitAbility();
        StartCoroutine(Coroutine);
    }
    public void SetChangeKey()
    {
        Change.text = "???";
        Coroutine = WaitChange();
        StartCoroutine(Coroutine);
    }
    IEnumerator WaitLeft()
    {
        while (true)
        {
            yield return null;
            foreach (KeyCode K in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(K))
                {
                    if (CurrentControls.CheckButton(K))
                    {
                        Left.text = CurrentControls.Left.ToString();
                        StopCoroutine(Coroutine);
                    }
                    else
                    {
                        CurrentControls.Left = K;
                        RefreshKeys();
                        Left.text = CurrentControls.Left.ToString();
                        StopCoroutine(Coroutine);
                    }
                }
            }
        }
    }
    IEnumerator WaitRight()
    {
        while (true)
        {
            yield return null;
            foreach (KeyCode K in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(K))
                {
                    if (CurrentControls.CheckButton(K))
                    {
                        Right.text = CurrentControls.Right.ToString();
                        StopCoroutine(Coroutine);
                    }
                    else
                    {
                        CurrentControls.Right = K;
                        RefreshKeys();
                        Right.text = CurrentControls.Right.ToString();
                        StopCoroutine(Coroutine);
                    }
                }
            }
        }
    }
    IEnumerator WaitJump()
    {
        while (true)
        {
            yield return null;
            foreach (KeyCode K in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(K))
                {
                    if (CurrentControls.CheckButton(K))
                    {
                        Jump.text = CurrentControls.Jump.ToString();
                        StopCoroutine(Coroutine);
                    }
                    else
                    {
                        CurrentControls.Jump = K;
                        RefreshKeys();
                        Jump.text = CurrentControls.Jump.ToString();
                        StopCoroutine(Coroutine);
                    }
                }
            }
        }
    }
    IEnumerator WaitInteract()
    {
        while (true)
        {
            yield return null;
            foreach (KeyCode K in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(K))
                {
                    if (CurrentControls.CheckButton(K))
                    {
                        Interact.text = CurrentControls.Interact.ToString();
                        StopCoroutine(Coroutine);
                    }
                    else
                    {
                        CurrentControls.Interact = K;
                        RefreshKeys();
                        Interact.text = CurrentControls.Interact.ToString();
                        StopCoroutine(Coroutine);
                    }
                }
            }
        }
    }
    IEnumerator WaitAbility()
    {
        while (true)
        {
            yield return null;
            foreach (KeyCode K in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(K))
                {
                    if (CurrentControls.CheckButton(K))
                    {
                        Ability.text = CurrentControls.Special.ToString();
                        StopCoroutine(Coroutine);
                    }
                    else
                    {
                        CurrentControls.Special = K;
                        RefreshKeys();
                        Ability.text = CurrentControls.Special.ToString();
                        StopCoroutine(Coroutine);
                    }
                }
            }
        }
    }
    IEnumerator WaitChange()
    {
        while (true)
        {
            yield return null;
            foreach (KeyCode K in KeyCode.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(K))
                {
                    if (CurrentControls.CheckButton(K))
                    {
                        Change.text = CurrentControls.Change.ToString();
                        StopCoroutine(Coroutine);
                    }
                    else
                    {
                        CurrentControls.Change = K;
                        RefreshKeys();
                        Change.text = CurrentControls.Change.ToString();
                        StopCoroutine(Coroutine);
                    }
                }
            }
        }
    }
}

