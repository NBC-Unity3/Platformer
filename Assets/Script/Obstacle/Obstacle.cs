using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ModeChoice
{
    UIManager uiManager;
    protected override void Start()
    {
        base.Start();
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (choice != Mode.Fix && choice != Mode.Hide &&
            (coll.gameObject.tag == "JumpGround" || coll.gameObject.tag == "Player"))
        {
            Destroy(gameObject);

            if (coll.gameObject.tag == "Player")
            {
                uiManager.endResult("한효승 매니저님이 진실의 방으로 끌고갔다");
                //TODO
                Debug.Log("Player부딪힘");
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player") //Fix인 Obstacle이랑 부딪혔을때
            {
                uiManager.endResult("유튜브의 알고리즘이 나를 현혹시킨다.");
                //TODO
                Debug.Log($"{gameObject.name} elsePlayer부딪힘");
            }
        }
    }
}
