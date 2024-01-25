using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColntroller : PlayerMovement
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpGround"))
        {
            if (bJump) return;

            Invoke("JumpOn", 0.05f);
        }

    }

    private void JumpOn()
    {
        bJump = true;
    }



    void PlayerDie()
    {
        Destroy(gameObject);
    }
}
