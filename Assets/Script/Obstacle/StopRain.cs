using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRain : MonoBehaviour
{
    public GameObject OnTrigger;
    private void OnTriggerEnter2D(Collider2D coll)
    { 
        if (coll.gameObject.tag == "Player")
        {
            Destroy(OnTrigger);
            Destroy(this.gameObject);
        }
    }
}
