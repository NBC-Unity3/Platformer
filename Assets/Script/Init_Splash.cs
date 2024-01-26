using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Init_Splash : MonoBehaviour
{
    private GameObject splashObj;
    private Image image;

    private bool CheckBool = false;

    private void Awake()
    {
        splashObj = this.gameObject;
        image = splashObj.GetComponent<Image>();
    }

    private void Update()
    {
        StartCoroutine("MainSplash");
        if (CheckBool)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator MainSplash()
    {
        Color color = image.color;

        for (int i = 0; i <= 255; i++)
        {
            color.a += Time.deltaTime * 0.002f;

            image.color = color;

            if (image.color.a >= 255)
            {
                CheckBool = true;
            }
        }
        yield return null;
    }

}
