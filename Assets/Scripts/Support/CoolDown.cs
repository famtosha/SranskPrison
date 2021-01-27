﻿using System;
using UnityEngine;

[Serializable]
public class CoolDown
{
    public float cd;
    private float cdLeft;

    public bool isReady => cdLeft < 0;
    public float left => cdLeft;

    public void UpdateTimer(float time) => cdLeft -= time;
    public void Reset() => cdLeft = cd;
    public void End() => cdLeft = 0;

    public CoolDown(float cd)
    {
        this.cd = cd;
    }
}
