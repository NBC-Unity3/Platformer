using System.Collections;
using System.Collections.Generic;
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
        if (collision.CompareTag("TIL")) 
        {
            StopAllCoroutines();
            Destroy(this);
        }
    }
}
