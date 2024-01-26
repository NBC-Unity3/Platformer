using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(Player.position.x, 0.6f, transform.position.z);
    }
}
