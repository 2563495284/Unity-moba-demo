using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
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
