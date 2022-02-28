using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public enum SkillEffect
{
    Q,
    W,
    E,
    R
}
public class EffectsManager : MonoBehaviour
{
    public static EffectsManager _instance;
    public GameObject objEffectQ;
    public GameObject objEffectW;
    public GameObject objEffectE;
    public GameObject objEffectR;
    private void Awake()
    {
        _instance=this;
    }

    private void Start()
    {
        objEffectQ = Resources.Load<GameObject>("Prefabs/charactor/LifeImpact");
        objEffectW = Resources.Load<GameObject>("Prefabs/charactor/Water");
        objEffectE = Resources.Load<GameObject>("Prefabs/charactor/ArcaneImpact");
        objEffectR= Resources.Load<GameObject>("Prefabs/charactor/AirSpray");
    }
    public void ShowSkillEffect(SkillEffect skillEffect,Vector3 pos)
    {
        switch (skillEffect)
        {
            case SkillEffect.Q:Instantiate(objEffectQ, pos,transform.rotation);
                break;
            case SkillEffect.W:Instantiate(objEffectW, pos,transform.rotation);
                break;
            case SkillEffect.E:Instantiate(objEffectE, pos,transform.rotation);
                break;
            case SkillEffect.R:Instantiate(objEffectR, pos,transform.rotation);
                break;
        }
    }
}
