using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Attack1,
    Attack2,
    AttackCritical,
    Cast,
    Death,
    Run,
    Walk,
    TakeDamage1,
    TakeDamage2,
    Skill_GroundImpact,
    Skill_MagicBall
    
}
public  class PlayerStates
{
    public static PlayerStates _instance;
    public static PlayerState state = PlayerState.Idle;
    public PlayerStates Instance()
    {
        if (_instance==null)
        {
            _instance = new PlayerStates();
            return _instance;
        }

        return _instance;
    }

    public static void toBeIdle()
    {
        state = PlayerState.Idle;
    }
}
