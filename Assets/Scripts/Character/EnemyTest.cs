using UnityEngine;
using System.Collections;

public class EnemyTest : MonoBehaviour
{

    public float _moveSpeed = 0;
    public float _jumpHeight = 0;

    Transform _attackPoint;
    public Character _char = null;
    Rigidbody2D _rigid;
    Animator _anim;
    Animation _run, attack;
    public bool _isGrounded;


    void Start()
    {
        _isGrounded = true;
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();

        _moveSpeed = _char.speed;
        _jumpHeight = _char.JumpForce;
        InvokeRepeating("Regenerate", 0.0f, 1.0f);
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

}
