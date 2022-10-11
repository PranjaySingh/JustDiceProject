using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 9f, player.transform.position.y + 2.5f, player.transform.position.z -22f);
    }
}
