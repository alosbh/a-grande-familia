using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public Transform player;
    void LateUpdate()
    {
        Vector3 newpos = player.position;
        newpos.y = transform.position.y;
        transform.position = newpos;
    }
}
