using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    void Start()
    {
        float x = Random.Range(-8.5f, -2.5f);// 값조절
        transform.position = new Vector3(x, 5f, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }        
        else if (coll.gameObject.tag == "Player")
        {
            //TODO
            
            
        }
    }


}


