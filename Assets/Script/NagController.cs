using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter (Collision col)
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
    }
}
