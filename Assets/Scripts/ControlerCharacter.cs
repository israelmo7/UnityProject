    using UnityEngine;
using System.Collections;

public class ControlerCharacter : MonoBehaviour
{

    public float _moveSpeed = 0;
    public float _jumpHeight = 0;
    //public bl_Joystick _Joystick;

    Transform _attackPoint;
    public Character _char = null;
    public Vector2 _speed = new Vector2();
    Rigidbody2D _rigid;
    Animator _anim;
    Animation _run, attack;
    public bool _isGrounded;
    private bool _IsHeld = false;
    public UserInterface _ui;
    public ButtonHandler _bHandler;

    public void Start()
    {
        _ui = GetComponent<UserInterface>();
        _isGrounded = true;
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
       // _Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<bl_Joystick>();

        _moveSpeed = _char.speed;
        _jumpHeight = _char.JumpForce;
        InvokeRepeating("Regenerate", 0.0f, 1.0f);
    }

    public void Update()
    {
        _speed.x = _bHandler.Value * _moveSpeed;

        _speed.y = _rigid.velocity.y;
        _rigid.velocity = _speed;
        if (_speed.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.zero);
        }
        else if(_speed.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        //Drop the flag
        if (Input.GetKeyDown(KeyCode.F))
        {
            _char.DropTheFlag();
        }
        //Attack

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _ui._mouseIsHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _ui._mouseIsHeld = false;
        }
        //Toggle
        short temp = (short)_char._skills.get().Count;
        for(short i=48; i<(temp+48); i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                _char.ToggleSkill((short)(i - 48));
            }
        }
    }
    public void wannaAttack(short index)
    {
        RotateToTarget();
        _char.ToggleSkill(index);
        if (_char.Attack())
        {
            Debug.Log("Inside Attack");
            _anim.SetTrigger("Attack1Trigger");
            CooldownSkill(_char.CounterSkill, _char._skills.get(_char.CounterSkill)._cooldownNeed);
            _char.Attack();
        }
    }
    public void wannaWalk(bool flag)
    {
        _anim.SetBool("Moving", flag);
    }
    public void wannaJump()
    {
        if (_isGrounded)
        {
            _char._isDoubleJumped = (_char._isDoubleJumped == '1') ? '0' : _char._isDoubleJumped;
            _rigid.velocity += new Vector2(0, _jumpHeight);
            //_anim.SetTrigger("IsJump");
        }
        else if (_char._isDoubleJumped == '0')
        {
            _char._isDoubleJumped = '1';
            _rigid.velocity += new Vector2(0, _jumpHeight);
            //_anim.SetTrigger("IsJump");
        }
        _isGrounded = false;
    }
    public void FixedUpdate()
    {
        //JumpCheck
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _char._isDoubleJumped = (_char._isDoubleJumped == '1') ? '0' : _char._isDoubleJumped;
                _rigid.velocity += new Vector2(0, _jumpHeight);
                //_anim.SetTrigger("IsJump");
            }
            else if (_char._isDoubleJumped == '0')
            {
                _char._isDoubleJumped = '1';
                _rigid.velocity += new Vector2(0, _jumpHeight);
                //_anim.SetTrigger("IsJump");
            }
            _isGrounded = false;
        }



    }
    public void Death()
    {
        Destroy(this);
    }
    public void CooldownSkill(short index, float delayTime)
    {
        StartCoroutine(_char.SetActive(index, delayTime));
    }
    private void Regenerate()
    {
        _char.Regenerate();
    }
    private void RotateToTarget()
    {
        // Rotate to the target
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.zero);
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
    }
}