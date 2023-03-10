using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public void StartCamera()
    {
        ScreenFader.fadeState = ScreenFader.FadeState.Out;
        ScreenFader.fadeSpeed = 2;
        ScreenFader.fromOutDelay = 1;
    }
    public void Awake()
    {
        ScreenFader = GetComponent<ScreenFader>();
        StartCamera();
    }
    public void EndCamera()
    {
        ScreenFader.fadeState = ScreenFader.FadeState.In;
        ScreenFader.fromOutDelay = 1;
    }
}
