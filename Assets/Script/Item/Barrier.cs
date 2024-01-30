using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    float duration = 30;

    public void EnableBarrior(float duration) 
    {
        StartCoroutine("barriorTimer");
    }

    IEnumerator barriorTimer() 
    {
        yield return new WaitForSeconds(duration);
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string[] tags = { "Bed", "Nintendo", "Youtube", };
        if (tags.Contains(collision.tag)) 
        {
            StopAllCoroutines();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
