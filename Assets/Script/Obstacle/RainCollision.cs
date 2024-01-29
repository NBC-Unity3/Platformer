using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "JumpGround" || coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            if (coll.gameObject.tag == "Player")
            {
                //TODO
                Debug.Log("Player부딪힘");
            }
        }
    }
}
