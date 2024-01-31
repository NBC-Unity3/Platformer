using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropCollision : MonoBehaviour
{
    UIManager uiManager;

    public Mode choice;

    private string bedStr = "폭신한 침대의 유혹에 지고 말았다.\n시계를 보니 밤 12시가 지났다....\n더 무서운건 퇴실버튼을 못 눌러서 매니저님이 찾아왔다..";
    private string nintendoStr = "몰래 게임을 하다가 걸려서 한효승 매니저님한테 진실의 방으로 끌려갔다...";
    private string clearStr = "  퇴  실  성  공  ! ! !\n\n모든 유혹을 뿌리치고 무사히 오늘의 공부와 TIL작성을 끝내고 퇴실에 성공했다!!!";
    private string mapOut = "공부를 때려치고 놀고싶은 욕망과\n주변의 많은 유혹들을 이겨내지 못하고 탈주를 해버렸다...";

    public enum Mode
    {
        Fix = 0,
        Drop,
        RandomRain,
        Rain,
        Fly,
        Hide
    }

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "MapOut")
            Destroy(gameObject);

        if (coll.gameObject.tag == "Nag")
            Destroy(coll.gameObject);

        if (choice == Mode.Fly && coll.gameObject.tag == "Ground")//wallTile
            Destroy(gameObject);

        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponentInChildren<Animator>().enabled = false;
            coll.gameObject.GetComponent<PlayerInput>().enabled = false;

            if (this.gameObject.tag == "Clear")
                uiManager.endResult(clearStr);
            if (this.gameObject.tag == "Bed")
                uiManager.endResult(bedStr);
            if (this.gameObject.tag == "Nintendo")
                uiManager.endResult(nintendoStr);

            Debug.Log($"{gameObject.tag} drop or fly랑 Player부딪힘");
        }
    }
}
        
