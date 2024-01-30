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
                if (this.gameObject.tag == "Clear")
                {
                    uiManager.endResult("Clear!");
                }
                if (this.gameObject.tag == "Bed")
                {
                    uiManager.endResult("폭신한 침대의 유혹에 지고 말았다.\n" +
                        "시계를 보니 밤 12시가 지났다....\n" +
                        "더 무서운건 퇴실버튼을 못 눌러서 매니저님이 찾아왔다..");
                }
                if (this.gameObject.tag == "Nintendo")
                    uiManager.endResult("몰래 게임을 하다가 걸려서 한효승 매니저님이 진실의 방으로 끌고갔다");

                Debug.Log($"{gameObject.tag} drop or fly랑 Player부딪힘");
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player") //Fix인 Obstacle이랑 부딪혔을때
            {
                if(this.gameObject.tag == "Clear")
                {
                    uiManager.endResult("Clear!");
                }
                if(this.gameObject.tag == "Bed")
                {
                    uiManager.endResult("폭신한 침대의 유혹에 지고 말았다.\n" +
                        "시계를 보니 밤 12시가 지났다....\n" +
                        "더 무서운건 퇴실버튼을 못 눌러서 매니저님이 찾아왔다..");
                }
                if (this.gameObject.tag == "Nintendo")
                    uiManager.endResult("몰래 게임을 하다가 걸려서 한효승 매니저님이 진실의 방으로 끌고갔다");
                
                Debug.Log($"{gameObject.tag} fix랑 Player부딪힘");
            }
        }
    }
}
