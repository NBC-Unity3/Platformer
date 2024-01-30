using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollision : MonoBehaviour
{
    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "JumpGround" || coll.gameObject.tag == "Player" || coll.gameObject.tag == "MapOut")
        {
            if (coll.gameObject.tag == "Player")
            {
                if (this.gameObject.tag == "YouTube")
                    uiManager.endResult("유튜브의 알고리즘이 나를 현혹시킨다...");

                Debug.Log($"{gameObject.tag} rain이랑 Player부딪힘");
            }

            Destroy(gameObject);
        }
    }
}
