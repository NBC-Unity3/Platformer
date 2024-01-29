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
            // ȿ����
            SoundManager.Instance.PlaySFX("");

            // ������ ���� ó��
            collision.GetComponent<PlayerColntroller>()?.CallOnPickUpItem(item);

            // ���� ������Ʈ ����
            Destroy(gameObject);
        }
    }
}
