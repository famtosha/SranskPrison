﻿using UnityEngine;

public static class InputUtils
{
    public static Vector2 GetMoveInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
