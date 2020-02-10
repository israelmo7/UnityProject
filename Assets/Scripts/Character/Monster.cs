using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {

    public Monster(CharType type) :
    base(type)
    {
    }
    public Monster(Transform owner, UserInterface ui, float speed, float jumpForce, int health, int maxHealth, int energy, int maxEnergy, int energyPerSec, float shield, string name, float damage) :
        base(owner, ui, speed, jumpForce, health, maxHealth, energy, maxEnergy, energyPerSec, shield, name, damage)
    {
        _type = CharType.Monster;
        //_health = 200;
        //_energy = 100;
        //_jumpForce = 10;
        //_speed = 5;
        //_shield = 40;
        //_name = "Monster";
        //_damage = 35;
        //_type = 0;
        
    }

}
