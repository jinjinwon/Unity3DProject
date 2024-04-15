using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public int HP { get { return hp; } set { hp = value;} }                     // ü��
    public int ATK { get { return atk; } set { atk = value; } }                 // ���ݷ�
    public int DEF { get { return def; } set { def = value; } }                 // ����
    public bool SKILL { get { return skill; } set { skill = value; } }          // ��ų ��� ����
    public int LEVEL { get { return level; } set { level = value; } }           // ����

    private int hp;
    private int atk;
    private int def;
    private bool skill;
    private int level;

    public AnimatorOverrideController controller;                               // �ִϸ��̼� ��Ʈ�ѷ�

    public abstract void OnAttack();
    public abstract void OnDamage();
    public abstract void OnSkill();
    public abstract void OnDie();
}
