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
            Destroy(gameObject);

            if (coll.gameObject.tag == "Player")
            {
                //TODO
                Debug.Log("Player부딪힘");
                uiManager.endResult("퇴실버튼을 못눌러서 매니저님이 찾아왔다");
            }
        }
    }
}
