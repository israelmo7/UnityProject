using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Main class for all player types
 * Type: 
 *          [0]-CanDoubleJump
 *          [1]-
 *          [2]-
 *          [3]-
 *          [4]-
 * 
 * 
 */ 
public class Character : GlobalObject
{
    public const int NUMBER_OF_TYPES = 5;
    public enum CharType
    {
        Ninja,
        Monster,
        Engineer
    }
    public AbilityType.Stype _stype =0;
    public CharType _type;
    protected UserInterface _ui;
    public bool _Redteam;
    protected float _speed;
    public float speed
    {
        get
        {
            return _speed;
        }
    }

    protected float _jumpForce;
    public float JumpForce
    {
        get
        {
            return _jumpForce;
        }
    }
    public char _isDoubleJumped;
    public Flag _hasFlag = null;
    [SerializeField]
    protected int _energy, _energyPerSec, _MaxEnergy;
    [SerializeField]
    protected int _health,_MaxHealth;

    protected float _damage;
    protected float _shield;

    protected string _name;

    [SerializeField]
    protected short _counterSkill = 0;
    public short CounterSkill
    {
        get
        {
            return _counterSkill;
        }
    }
    public SkillsList _skills = new SkillsList(NUMBER_OF_TYPES);
    
    [SerializeField]
    public short _score = 0;


    public Character(CharType type)
    {
        _type = type;
        _health = 100;
        _energy = 100;
        _energyPerSec = 2;
        _MaxEnergy = 100;
        _MaxHealth = 100;
        _shield = 30;
        _speed = 10;
        _Redteam = true;
    }
    public Character(Transform owner, UserInterface ui, float speed, float jumpForce, int health, int maxHealth, int energy, int maxEnergy, int energyPerSec, float shield, string name, float damage)
    {
        _Redteam = true;
        _ui = ui;
        _speed = speed;
        _jumpForce = jumpForce;
        _health = health;
        _MaxHealth = maxHealth;
        _MaxEnergy = maxEnergy;
        _energyPerSec = energyPerSec;
        _shield = shield;
        _name = name;
        _damage = damage;
        _isDoubleJumped = 'n';
        InitSkills(owner);
        //
    }
    public void ChangeAbiltyType(int stype)
    {
        _skills.CurrentIndex = stype;
    }
    protected bool CanAttack()
    {
        if(_skills.get(_counterSkill)._energy <= _energy && _skills.get(_counterSkill).CheckAndUse())
        {
            _energy -= _skills.get(_counterSkill)._energy;
            _ui.SetManaBar(_energy, _MaxEnergy);
            return true;
        }
        return false;
    }
    virtual public bool Attack()
    {

        return false;

    }
    virtual public void iHitSomeone(Character _target, short damage)
    {

    }
    public void ToggleSkill(short num)
    {
        if(num < _skills.get().Count && num >= 0)
        {
            _counterSkill = num;
            _ui.ToggleSkillImage(num);
            Debug.Log("Skill changed to '" + _skills.get(_counterSkill)._name + "'");
        }

    }
    public void IsAttacked(float damage)
    {
        _health -= (int)((100-_shield)/100*damage);
        if (_health <= 0)
            Death();
        if(_ui)
                _ui.SetHelathBar(_health, _MaxHealth);
    }
    virtual protected void InitSkills(Transform owner)
    {

    }
    public IEnumerator SetActive(short index, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // Now do your thing here

        _skills.get(_counterSkill)._active = true;
    }
    public void SetFlag(Flag f)
    {
        _hasFlag = f;
        Debug.Log("Flag : "+f);
    }
    public void DropTheFlag()
    {
        if (_hasFlag)
        {
            _hasFlag.DropTheFlag();
            _hasFlag = null;
        }
    }
    public void Regenerate()
    {
        if (_energy < _MaxEnergy)
        {
            _energy = (_energy + _energyPerSec > _MaxEnergy) ? _MaxEnergy : _energy + _energyPerSec;
            _ui.SetManaBar(_energy, _MaxEnergy);
        }
        if (_health < _MaxHealth)
        { 
            int healthPerSec = _energyPerSec /2;
            _health = (_health + healthPerSec > _MaxHealth) ? _MaxHealth : _health + healthPerSec;
            _ui.SetHelathBar(_health, _MaxHealth);
        }
    }
    private void Death()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<ControlerCharacter>().Death();
    }
    public virtual void UseSomeSkill()
    {

    }
}
