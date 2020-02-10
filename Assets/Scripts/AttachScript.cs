using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachScript : MonoBehaviour {

    Transform _target;
	// Use this for initialization
	void Start () {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(_target.position.x,_target.position.y+2,0);
	}
}
