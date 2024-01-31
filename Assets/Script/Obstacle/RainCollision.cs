using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class RainCollision : MonoBehaviour
{
    UIManager uiManager;

    private string youtubeStr = "유튜브의 알고리즘이 나를 현혹시킨다...\n12시간동안 유튜브에서 헤어나오지 못했다...";

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        string[] tags = { "JumpGround", "Player", "MapOut", "Nag", "Bed" };

        if(tags.Contains(coll.gameObject.tag))
        {
            if (coll.gameObject.tag == "Player")
            {
                coll.gameObject.GetComponentInChildren<Animator>().enabled = false;
                coll.gameObject.GetComponent<PlayerInput>().enabled = false;

                if (this.gameObject.tag == "YouTube")
                    uiManager.endResult(youtubeStr);

                Debug.Log($"{gameObject.tag} rain이랑 Player부딪힘");
            }

            Destroy(gameObject);
        }
    }
}
