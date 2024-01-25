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

            bJump = true;
        }

    }


    void PlayerDie()
    {
        Destroy(gameObject);
    }
}
