using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public int HP { get { return hp; } set { hp = value;} }                     // 체력
    public int ATK { get { return atk; } set { atk = value; } }                 // 공격력
    public int DEF { get { return def; } set { def = value; } }                 // 방어력
    public bool SKILL { get { return skill; } set { skill = value; } }          // 스킬 사용 여부
    public int LEVEL { get { return level; } set { level = value; } }           // 레벨

    private int hp;
    private int atk;
    private int def;
    private bool skill;
    private int level;

    public AnimatorOverrideController controller;                               // 애니메이션 컨트롤러

    public abstract void OnAttack();
    public abstract void OnDamage();
    public abstract void OnSkill();
    public abstract void OnDie();
}
