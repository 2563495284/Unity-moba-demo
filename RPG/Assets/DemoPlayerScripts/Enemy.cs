using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayerControl
{
    private void OnMouseEnter()
    {
        CursorManager._instance.SetAttack();
    }

    private void OnMouseExit()
    {
        CursorManager._instance.SetNormal();
    }
}
