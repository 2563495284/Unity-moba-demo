using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animation _animation;
    public EnemyProperty enemyProperty;
    private void Start()
    {
        enemyProperty = this.GetComponent<EnemyProperty>();
        _animation = this.GetComponent<Animation>();
        
    }

    private void LateUpdate()
    {
        switch (enemyProperty.enemyState)
        {
            case PlayerState.Attack1:PlayAnims("Attack1");
                break;
            case PlayerState.Attack2:PlayAnims("Attack2");
                break;
            case PlayerState.AttackCritical:PlayAnims("AttackCritical");
                break;
            case PlayerState.Cast:PlayAnims("Cast");
                break;
            case PlayerState.Death:PlayAnims("Death");
                break;
            case PlayerState.Walk:PlayAnims("Walk");
                break;
            case PlayerState.Run:PlayAnims("Run");
                break;
            case PlayerState.TakeDamage1:PlayAnims("TakeDamage1");
                break;
            case PlayerState.TakeDamage2:PlayAnims("TakeDamage2");
                break;
            case PlayerState.Skill_GroundImpact:PlayAnims("Skill-GroundImpact");
                break;
            case PlayerState.Skill_MagicBall:PlayAnims("Skill-MagicBall");
                break;
            case PlayerState.Idle:PlayAnims("Idle");
                break;
            
        }
    }

    void PlayAnims(string animationName)
    {
        _animation.CrossFade(animationName);
    }
}
