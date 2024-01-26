using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Typing(dialogText.text));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            print(letter);
            yield return new WaitForSeconds(1f);
        }
    }
}
