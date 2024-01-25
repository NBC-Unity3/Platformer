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

            bMove = true;
            Invoke("JumpOn", 0.05f);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            bMove = false;
            //rigidbody.velocity = Vector2.zero;
        }


    }

    private void JumpOn()
    {
        bJump = true;
    }

    private void MoveOn()
    {
        bMove = true;
    }

    void PlayerDie()
    {
        Destroy(gameObject);
    }
}
