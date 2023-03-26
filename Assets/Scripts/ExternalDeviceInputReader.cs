using System;
using Player;
using UnityEngine;

public class ExternalDeviceInputReader : IEntityInputSource
{
    public float HorizontalDirection => Input.GetAxis("Horizontal");
    public float VerticalDirection => Input.GetAxis("Vertical");
    public bool Use { get; private set; }

    public void OnUpdate()
    {
        if (Input.GetButtonDown("Use"))
        {
            Use = true;
        }
    }

    public void ResetOneTimeActions()
    {
        Use = false;
    }
}