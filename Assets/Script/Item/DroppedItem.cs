using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class DroppedItem : MonoBehaviour
{
    [SerializeField]
    Item item;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            // 효과음
            SoundManager.Instance.PlaySFX("");

            // 아이템 습득 처리
            collision.GetComponent<PlayerColntroller>()?.CallOnPickUpItem(item);

            // 현재 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
