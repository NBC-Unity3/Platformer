using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedUp : Item
{
    [SerializeField]
    int addSpeed = 3;

    public override void ConsumeItem(GameObject player)
    {
        StartCoroutine("AddSpeed", player);
    }

    IEnumerator AddSpeed(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        SpriteRenderer spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();

        Debug.Log("Add Speed");
        movement.speed += addSpeed;
        spriteRenderer.color = Color.yellow;

        yield return new WaitForSeconds(duration);


        Debug.Log("Add Speed");
        movement.speed -= addSpeed;
        spriteRenderer.color = Color.white;

        Destroy(this);
    }
}
