using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColntroller : PlayerMovement
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpGround"))
        {

            // �浹 ������ �ϳ� �̻� �ִ� ���
            if (collision.contacts.Length > 0)
            {
                // �浹 ���� ���� ���
                ContactPoint2D contact = collision.contacts[0];

                // �浹�� ������ Ȯ���Ͽ� �浹 ���� ����
                if (Mathf.Abs(contact.normal.y) > Mathf.Abs(contact.normal.x))
                {
                    // ���� �浹 (�� �Ǵ� �Ʒ�����)
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
