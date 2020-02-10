//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///* Main class for all player types
// * Type: 
// *          [0]-CanDoubleJump
// *          [1]-
// *          [2]-
// *          [3]-
// *          [4]-
// * 
// * 
// */ 
//public class Character : MonoBehaviour
//{
//    UserInterface _ui;
//    public bool _Redteam;
//    protected float _speed;
//    public float speed
//    {
//        get
//        {
//            return _speed;
//        }
//    }

//    protected float _jumpForce;
//    public float JumpForce
//    {
//        get
//        {
//            return _jumpForce;
//        }
//    }
//    public bool _isDoubleJumped;
//    public Flag _hasFlag = null;
//    [SerializeField]
//    protected int _energy, _energyPerSec, _MaxEnergy;
//    [SerializeField]
//    protected int _health,_MaxHealth;

//    protected float _damage;
//    protected float _shield;

//    protected short _type = 0;
//    public short type
//    {
//        get
//        {
//            return _type;
//        }
//    }
//    protected string _name;

//    [SerializeField]
//    protected short _counterSkill = 0;
//    public short CounterSkill
//    {
//        get
//        {
//            return _counterSkill;
//        }
//    }
//    public List<Skill> _skills = new List<Skill>();
//    [SerializeField]
//    protected Transform _attackPoint=null;
//    public short _score = 0;

//    private void Start()
//    {
//        _ui = GetComponent<UserInterface>();
//        _speed = 10;
//        _jumpForce = 10;
//        InitSkills();
//        InvokeRepeating("Regenerate", 0.0f, 1.0f);
//    }

//    protected bool CanAttack()
//    {
//        if(_skills[_counterSkill]._energy <= _energy && _skills[_counterSkill].CheckAndUse())
//        {
//            _energy -= _skills[_counterSkill]._energy;
//            _ui.SetManaBar(_energy, _MaxEnergy);
//            return true;
//        }
//        return false;
//    }

//    virtual public void Attack(Animator anim)
//    {

//    }
//    virtual public void iHitSomeone(Character _target, short damage)
//    {

//    }
//    public void ToggleSkill(short num)
//    {
//        if(num < _skills.Count && num >= 0)
//        {
//            _counterSkill = num;
//            _ui.ToggleSkillImage(num);
//            Debug.Log("Skill changed to '" + _skills[_counterSkill]._name + "'");
//        }

//    }
//    public void IsAttacked(float damage)
//    {
//        _health -= (int)((100-_shield)/100*damage);
//        if (_health <= 0)
//            Death();
//        if(_ui)
//                _ui.SetHelathBar(_health, _MaxHealth);
//    }
//    virtual protected void InitSkills()
//    {
//    }
//    private void Death()
//    {
//        Destroy(gameObject);
//    }
//    protected IEnumerator SetActive(short index, float delayTime)
//    {
//        yield return new WaitForSeconds(delayTime);
//        // Now do your thing here

//        _skills[index]._active = true;
//    }
//    public void SetFlag(Flag f)
//    {
//        _hasFlag = f;
//        Debug.Log("Flag : "+f);
//    }
//    public void DropTheFlag()
//    {
//        if (_hasFlag)
//        {
//            _hasFlag.DropTheFlag();
//            _hasFlag = null;
//        }
//    }
//    private void Regenerate()
//    {
//        if (_energy < _MaxEnergy)
//        {
//            _energy = (_energy + _energyPerSec > _MaxEnergy) ? _MaxEnergy : _energy + _energyPerSec;
//            _ui.SetManaBar(_energy, _MaxEnergy);
//        }
//    }
//}
