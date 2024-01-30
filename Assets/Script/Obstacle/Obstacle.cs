using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Obstacle : ModeChoice
{
    UIManager uiManager;

    private string bedStr = "폭신한 침대의 유혹에 지고 말았다.\n시계를 보니 밤 12시가 지났다....\n더 무서운건 퇴실버튼을 못 눌러서 매니저님이 찾아왔다..";
    private string nintendoStr = "몰래 게임을 하다가 걸려서 한효승 매니저님한테 진실의 방으로 끌려갔다...";
    private string clearStr = "모든 유혹을 뿌리치고 무사히 오늘의 공부와 TIL작성을 끝내고 퇴실에 성공했다!!!";
    private string mapOut = "낙사";

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
            coll.gameObject.GetComponentInChildren<Animator>().enabled = false;
            coll.gameObject.GetComponent<PlayerInput>().enabled = false;

            if (coll.gameObject.tag == "Player")
            {
                if (this.gameObject.tag == "Clear")
                    uiManager.endResult(clearStr);
                if (this.gameObject.tag == "Bed")
                    uiManager.endResult(bedStr);
                if (this.gameObject.tag == "Nintendo")
                    uiManager.endResult(nintendoStr);

                Debug.Log($"{gameObject.tag} drop or fly랑 Player부딪힘");
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player") //Fix인 Obstacle이랑 부딪혔을때
            {
                coll.gameObject.GetComponentInChildren<Animator>().enabled = false;
                coll.gameObject.GetComponent<PlayerInput>().enabled = false;

                if (this.gameObject.tag == "Clear")
                    uiManager.endResult(clearStr);
                if(this.gameObject.tag == "Bed")
                    uiManager.endResult(bedStr);
                if (this.gameObject.tag == "Nintendo")
                    uiManager.endResult(nintendoStr);
                if (this.gameObject.tag == "MapOut")
                    uiManager.endResult(mapOut);

                Debug.Log($"{gameObject.tag} fix랑 Player부딪힘");
            }
        }
    }
}
