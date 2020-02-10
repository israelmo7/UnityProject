using UnityEngine;

public class Flag : MonoBehaviour
{
    public bool _RedTeam;
    bool _InBase;
    bool _IsFree;
    Transform _Parent;
    public Vector3 _BasePosition;
    ControlerCharacter _Catcher = null;
    public BoxCollider2D _boxColl;

    private void Start()
    {
        _BasePosition = transform.position;
        _InBase = true;
        _IsFree = true;
        _Parent = transform.parent;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void ReturnToBase()
    {
        Debug.Log("Name: " +gameObject.name);
        _boxColl.enabled = true;
        transform.SetParent(_Parent);
        transform.position = _BasePosition;
        transform.rotation = Quaternion.identity;
        _IsFree = true;
        _InBase = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
    public void DropTheFlag()
    {
        _boxColl.enabled = true;
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        _IsFree = true;
        _Catcher.transform.Find("FlagSign").GetComponent<SpriteRenderer>().enabled = false;
        _Catcher = null;
        transform.SetParent(null);
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, 0); 
        rg.AddForce(Vector2.up * 5);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ControlerCharacter c = collision.GetComponent<ControlerCharacter>();
        if (c != null)
        {
            Character ch = c._char;
            if (_RedTeam == ch._Redteam) // Same Team
            {
                if (!_InBase && _IsFree) // isnt in Base
                {
                    ReturnToBase();
                }
                else if(_InBase && ch._hasFlag) // is in base
                {
                    ch._hasFlag.ReturnToBase();
                    ch.SetFlag(null);
                    collision.transform.Find("FlagSign").GetComponent<SpriteRenderer>().enabled = false;
                    ch._score++;
                }
            }
            else
            {
                if (_IsFree) // Someone catch the flag
                {
                    _Catcher = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlerCharacter>();
                    _Catcher.transform.Find("FlagSign").GetComponent<SpriteRenderer>().enabled = true;
                    ch.SetFlag(this);
                    _IsFree = false;
                    _InBase = false;
                    transform.SetParent(collision.transform);
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    //transform.localPosition = Vector3.up;
                }
            }
        }

    }
}
