using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

[System.Serializable]
[CreateAssetMenu(fileName = "SettingsValues", menuName = "Settings Values", order = 51)]
public class SettingsValues : ScriptableObject
{
    public AudioMixer MusicMixer;
    public AudioMixer EffectsMixer;
    public int Width;
    public int Height;
    public float MusicMixerValue;
    public float EffectsMixerValue;
    public void LoadSettings()
    {

        if (Width == 0 || Height == 0)
        {
            Width = Screen.currentResolution.width;
            Height = Screen.currentResolution.height;
        }
        Screen.SetResolution(Width, Height, true);
        MusicMixer.SetFloat("AudioVolume", MusicMixerValue);
        EffectsMixer.SetFloat("EffectsVolume", EffectsMixerValue);
    }
}
