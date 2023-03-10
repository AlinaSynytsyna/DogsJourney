using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class Settings : MonoBehaviour
{
    public Text MusicValueText;
    public Text EffectsValueText;
    public Controls Controls;
    List<string> Resolutions = new List<string>();
    public SettingsValues Values;
    public AudioMixer MusicMixer;
    public AudioMixer EffectsMixer;
    public Dropdown DropdownResolutions;
    public Slider MusicSlider;
    public Slider EffectsSlider;
    List<Resolution> Rsl;
    public void SetUpSettings()
    {
        Resolutions.Clear();
        Rsl = Screen.resolutions.ToList<Resolution>();
        foreach (var i in Rsl)
        {
            Resolutions.Add(i.width + "x" + i.height);
        }
        DropdownResolutions.ClearOptions();
        DropdownResolutions.AddOptions(Resolutions);
        DropdownResolutions.value = Resolutions.IndexOf(Values.Width.ToString() + "x" + Values.Height.ToString());
        MusicSlider.value = Values.MusicMixerValue;
        EffectsSlider.value = Values.EffectsMixerValue;
    }
    public void MusicVolume(float SliderMusicValue)
    {
        MusicMixer.SetFloat("AudioVolume", SliderMusicValue);
        MusicMixer.GetFloat("AudioVolume", out Values.MusicMixerValue);
        MusicValueText.text = "Громкость музыки: " + (SliderMusicValue + 50);
    }
    public void EffectsVolume(float SliderEffectsValue)
    {
        EffectsMixer.SetFloat("EffectsVolume", SliderEffectsValue);
        EffectsMixer.GetFloat("EffectsVolume", out Values.EffectsMixerValue);
        EffectsValueText.text = "Громкость эффектов: " + (SliderEffectsValue + 50);
    }
    public void ChangeResolution()
    {
        Values.Width = Rsl[DropdownResolutions.value].width;
        Values.Height = Rsl[DropdownResolutions.value].height;

        Screen.SetResolution(Values.Width, Values.Height, true);
    }
    public void SaveSettings()
    {
        MusicMixer.GetFloat("AudioVolume", out Values.MusicMixerValue);
        EffectsMixer.GetFloat("EffectsVolume", out Values.EffectsMixerValue);
        Values.Width = Rsl[DropdownResolutions.value].width;
        Values.Height = Rsl[DropdownResolutions.value].height;
        this.gameObject.SetActive(false);
    }
    public void OpenControls()
    {
        Controls.gameObject.SetActive(true);
        Controls.SetUpKeys();
        this.gameObject.SetActive(false);
    }
}

