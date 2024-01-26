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

            
            Panel.SetActive(true);
            Invoke("LoadSleepScene", 3f);
        }
    }

    private void LoadSleepScene()
    {
        SceneManager.LoadScene("SleepScene");
    }
}
