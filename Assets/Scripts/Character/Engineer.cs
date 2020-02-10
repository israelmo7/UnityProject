using UnityEngine;
using System.Collections;

public class Engineer : Character
{
    public Engineer(Transform owner, UserInterface ui, float speed, float jumpForce,int health,int maxHealth,int energy, int maxEnergy, int energyPerSec, float shield,string name, float damage):
        base(owner, ui, speed, jumpForce, health, maxHealth, energy, maxEnergy, energyPerSec, shield, name, damage)
    {
        _type = CharType.Engineer;
    }
    override protected void InitSkills(Transform owner)
    {
        Skill.SetGST(GameObject.Find("Manager").GetComponent<GlobalScriptTeam>());

        Transform attackPoint = owner.GetChild(2);
        Fist fist = new Fist(owner, "Fist", 10, 1, 0, 1f, Skill.SkillType.Melee, attackPoint, 100);
        Shuriken shuriken = new Shuriken(owner, "Shuriken", 25, 3, 10, 3f, Skill.SkillType.Ranged, 1000, 4, attackPoint);
        Grenade grenade = new Grenade(owner, "Grenade", 35, 12, 15, 10, Skill.SkillType.Ranged, 500, 5, attackPoint);
        _skills.set(fist);
        _skills.set(shuriken);
        _skills.set(grenade);
    }
}
