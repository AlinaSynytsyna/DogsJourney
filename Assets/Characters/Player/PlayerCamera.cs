using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera Camera;
    public float minPosition;
    public float maxPosition;
    public float moveSpeed = 1.0f;
    private Player Player;
    private Vector3 Offset;
    public ScreenFader ScreenFader;
    public void StartCamera()
    {
        ScreenFader.fadeSpeed = 1F;
        ScreenFader.fromOutDelay = 2;
        ScreenFader.fadeState = ScreenFader.FadeState.Out;
    }
    public void EndCamera()
    {
        ScreenFader.fadeSpeed = 2F;
        ScreenFader.fromInDelay = 1;
        ScreenFader.fadeState = ScreenFader.FadeState.In;
    }
    public void Awake()
    {
        Camera = GetComponent<Camera>();
        Player = GetComponentInParent<Player>();
        Offset = transform.position - Player.transform.position;
        ScreenFader = GetComponent<ScreenFader>();
        StartCamera();
    }
    public void LateUpdate()
    {
        if (Player == null)
        {
            return;
        }
        Offset = Vector3.Lerp(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        Offset.x = Mathf.Clamp(Offset.x, minPosition, maxPosition);
        Offset.y = transform.position.y;
        Offset.z = transform.position.z;
        transform.position = Offset;
    }
}

