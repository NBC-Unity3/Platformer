using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer itemSprite { get; private set; }

    [SerializeField]
    protected float duration;

    private void Awake()
    {
        itemSprite = GetComponent<SpriteRenderer>();
    }

    public virtual void ConsumeItem(GameObject player) { }
}
