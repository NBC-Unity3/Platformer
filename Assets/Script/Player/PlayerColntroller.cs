using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColntroller : PlayerMovement
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpGround"))
        {

            // 충돌 지점이 하나 이상 있는 경우
            if (collision.contacts.Length > 0)
            {
                // 충돌 지점 정보 사용
                ContactPoint2D contact = collision.contacts[0];

                // 충돌의 법선을 확인하여 충돌 방향 결정
                if (Mathf.Abs(contact.normal.y) > Mathf.Abs(contact.normal.x))
                {
                    // 수직 충돌 (위 또는 아래에서)
                    if (JumpOn) return;

                    if (JumpOn) return;

                    var velocity = rigidbody.velocity;
                    velocity.y = 0;
                    rigidbody.velocity = velocity;

                    JumpOn = true;
                    Secondjump = false;
                }
            }
        }
    }


    void PlayerDie()
    {
        Destroy(gameObject);
    }
}
