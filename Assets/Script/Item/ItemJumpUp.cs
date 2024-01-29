using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJumpUp : Item
{
    [SerializeField]
    float addJumpPower = 10;

    public override void ConsumeItem(GameObject player)
    {
        StartCoroutine("AddJump", player);
    }

    IEnumerator AddJump(GameObject player) 
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        SpriteRenderer spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();

        Debug.Log("Add Jump");
        movement.jump += addJumpPower;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(duration);


        Debug.Log("Rollback Jump");
        movement.jump -= addJumpPower;
        spriteRenderer.color = Color.white;

        Destroy(this);
    }
}
