using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ModeChoice
{
    protected override void Start()
    {
        base.Start();


    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (choice != Mode.Fix && choice != Mode.Hide &&
            (coll.gameObject.tag == "JumpGround" || coll.gameObject.tag == "Player"))
        {
            Destroy(gameObject);

            if (coll.gameObject.tag == "Player")
            {
                //TODO
                Debug.Log("Player부딪힘");
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player") //Fix인 Obstacle이랑 부딪혔을때
            {
                //TODO
                Debug.Log($"{gameObject.name} elsePlayer부딪힘");
            }
        }
    }
}
