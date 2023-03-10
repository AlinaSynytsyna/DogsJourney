using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CustomInput", menuName = "Custom Input", order = 52)]
public class CustomInput : ScriptableObject
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    public KeyCode Special;
    public KeyCode Interact;
    public KeyCode Change;
    public List<KeyCode> KeyCodes;
    public bool CheckButton(KeyCode Code)
    {
        if (KeyCodes.Contains(Code) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0))
            return true;
        else return false;
    }
}