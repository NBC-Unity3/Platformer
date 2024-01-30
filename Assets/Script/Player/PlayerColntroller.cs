using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColntroller : PlayerMovement
{
    // UI 갱신을 위한 이벤트
    public event Action<Item> OnPickUpItem;


    [SerializeField]
    Item item = null;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpGround"))
        {

            // 충돌 지점이 하나 이상 있는 경우
            if (collision.contacts.Length > 0)
            {
                ContactPoint2D contact = collision.contacts[0];

                // 충돌의 법선을 확인하여 충돌 방향 결정
                if (contact.normal.y > 0.9f && Mathf.Abs(contact.normal.x) < 0.1f)
                {
                    if (JumpOn) return;

                    animation.ClearJump();

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

    public void CallOnPickUpItem(Item newItem) 
    {   
        if(item != null) 
        {
            Destroy(item.gameObject);
        }

        this.item = newItem;
        newItem.itemSprite.enabled = false;
        newItem.transform.parent = transform;
        newItem.transform.localPosition = Vector3.zero;

        OnPickUpItem?.Invoke(newItem);
    }

    public void CallOnConsumeItem() 
    {
        item?.ConsumeItem(this.gameObject);
        item = null;
    }
}
