using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Character {

    public bool _hit = false;

    public Ninja (CharType type):
        base(type)
    {
    }
    public Ninja(Transform owner, UserInterface ui, float speed, float jumpForce,int health,int maxHealth,int energy, int maxEnergy, int energyPerSec, float shield,string name, float damage):
        base(owner, ui,speed,jumpForce,health,maxHealth,energy,maxEnergy,energyPerSec,shield,name,damage)
    {
        _type = CharType.Ninja;
        _isDoubleJumped = '0';
        //_health = 100;
        //_MaxHealth = 100;
        //_energy = 100;
        //_MaxEnergy = 100;
        //_energyPerSec = 2;
        //_jumpForce = 8;
        //_speed = 7;
        //_shield = 20;
        //_name = "Ninja";
        //_damage = 14;
        //_type |= 1;
        //_isDoubleJumped = false;
    }
    override protected void InitSkills(Transform owner)
    {
        Skill.SetGST(GameObject.Find("Manager").GetComponent<GlobalScriptTeam>());
        
        Transform attackPoint = owner.GetChild(2);


        Fist fist = new Fist(owner, "Fist", 10, 1, 0, 1f, Skill.SkillType.Melee, attackPoint, 100);
        Shuriken shuriken = new Shuriken(owner, "Shuriken", 25, 3, 10, 3f, Skill.SkillType.Ranged, 1000, 4, attackPoint);
        Grenade grenade = new Grenade(owner, "Grenade", 35, 12, 15, 10, Skill.SkillType.Ranged, 500, 5, attackPoint);
        _skills.set((int)AbilityType.Stype.None, fist);
        _skills.set((int)AbilityType.Stype.None, shuriken);
        _skills.set((int)AbilityType.Stype.None, grenade);

        FireBall fireBall = new FireBall(owner, "FireBall", 35, 3, 15, 3f, Skill.SkillType.Ranged, 1000, 4, attackPoint);

        _skills.set((int)AbilityType.Stype.Fire, fist);
        _skills.set((int)AbilityType.Stype.Fire, fireBall);

        Tornado tornado = new Tornado(owner, "Tornado", 100, 0, 20, 15, Skill.SkillType.OnArea, 5, 5);
        _skills.set((int)AbilityType.Stype.Wind, fist);
        _skills.set((int)AbilityType.Stype.Wind, tornado);

    }

    override public void iHitSomeone(Character _target, short damage)
    {
        _target.IsAttacked(damage);
    }
    override public bool Attack()
    {

        if (!CanAttack())
            return false;

        //The Attack
        GameObject temp = _skills.get(_counterSkill).UseAbility();
        if(temp)
        {
            ControlerCharacter c = temp.GetComponent<ControlerCharacter>();
            if(c /*|| temp.tag == "Enemy"*/) // melee attacks
            {
                
                Debug.Log("Hit");
                c._char.IsAttacked(_skills.get(_counterSkill)._value);
            }
        }
        return true;

    }
    public override void UseSomeSkill()
    {

    }
}
