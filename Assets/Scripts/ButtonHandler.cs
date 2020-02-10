using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    private int _value;
    private ControlerCharacter _cc;

    public int Value
    {
        get
        {
            return _value;
        }
    }
    // Use this for initialization
    void Start()
    {
        _value = 0;
        _cc = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlerCharacter>();
        _cc._bHandler = this;
    }
    public void wannaAttack(short i =0)
    {
        _cc.wannaAttack(i);
    }
    public void wannaWalk(int hor)
    {
        _value = hor;
        _cc.wannaWalk((hor != 0));
    }
    public void wannaJump()
    {
        _cc.wannaJump();
    }
    public GameObject getChild(int i)
    {
        return transform.GetChild(i).gameObject;
    }
    public void IsHeld(bool flag)
    {
        GetComponent<LineDrawer>()._isHeldInArea = flag;        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
