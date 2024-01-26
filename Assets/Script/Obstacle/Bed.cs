using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    public GameObject Panel;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //TODO

            //애니메이션 등
            Panel.SetActive(true);
            Invoke("LoadDeadScene", 3f);
        }
    }

    private void LoadDeadScene()
    {
        SceneManager.LoadScene("DeadScene");
    }
}
