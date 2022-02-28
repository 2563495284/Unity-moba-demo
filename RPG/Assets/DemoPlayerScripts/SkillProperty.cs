using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillProperty
    {
        public float coolDown; //冷却时间
        public float currentCoolDown; //当前冷却时间
        public bool isSkill; //是否使用技能
        public Image icon; //图标
        public SkillType skillType; //技能类型
        public SkillAreaType skillAreaType; //技能技能范围类型
        public PlayerState playerState; //人物动画
        public SkillEffect skillEffect; //技能QWER
        public float damage; //伤害


        public SkillProperty(float coolDown, SkillType skillType, SkillAreaType skillAreaType, PlayerState playerState,
            Image icon, SkillEffect skillEffect, float damage)
        {
            this.playerState = playerState;
            this.skillEffect = skillEffect;
            this.icon = icon;
            this.skillType = skillType;
            this.skillAreaType = skillAreaType;
            this.coolDown = coolDown;
            this.damage = damage;
            currentCoolDown = coolDown;
            isSkill = false;
        }
}

