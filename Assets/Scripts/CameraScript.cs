using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void LateUpdate ()
    {
        if (!player)
            return;
        Vector3 temp = player.transform.position;
        temp.z = -10;
        //temp.y += 0;
        transform.position = temp;
    }
}
