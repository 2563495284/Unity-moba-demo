using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager _instance;
    public Texture2D cursor_normal;
    public Texture2D cursor_npc_talk;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D pick;
    public Vector2 hotspot=Vector2.zero;
    private CursorMode _mode = CursorMode.Auto;
    private void Awake()
    {
        _instance = this;
        cursor_attack = Resources.Load<Texture2D>("mouse cursor/Cursor-Attack");
        cursor_npc_talk = Resources.Load<Texture2D>("mouse cursor/Cursor-Npc Talk");
        cursor_normal = Resources.Load<Texture2D>("mouse cursor/Cursor-Normal");

        cursor_lockTarget = Resources.Load<Texture2D>("mouse cursor/Cursor-LockTarget");

        pick = Resources.Load<Texture2D>("mouse cursor/Cursor-Pick");

    }
    public void SetNormal()
    {
        Cursor.SetCursor(cursor_normal,hotspot,_mode);
    }

    public void SetNpcTalk()
    {
        Cursor.SetCursor(cursor_npc_talk,hotspot,_mode);
    }

    public void SetAttack()
    {
        Cursor.SetCursor(cursor_attack,hotspot,_mode);
    }
    public void SetLockTarget()
    {
        Cursor.SetCursor(cursor_lockTarget,hotspot,_mode);
    }
    public void Setpick()
    {
        Cursor.SetCursor(pick,hotspot,_mode);
    }

}
