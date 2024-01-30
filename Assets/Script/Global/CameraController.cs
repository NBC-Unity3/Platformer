using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        
    }

    void Update()
    {
        if (Player.position.x < 0) return;
        transform.position = new Vector3(Player.position.x, 0.6f, transform.position.z);
    }
}
