using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGridScroller : MonoBehaviour
{
    [SerializeField]
    public float scrollSpeed = 1.0f;

    [SerializeField]
    float width = 21;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(scrollSpeed * Time.fixedDeltaTime, 0, 0);

        // 1920x1080 images has 19.2 width (in PixelPerUnit 100)
        if (transform.position.x < Camera.main.transform.position.x - width * 0.99)
        {
            transform.position = new Vector3(transform.position.x + width * 2, transform.position.y, transform.position.z);
        }

        if (transform.position.x > Camera.main.transform.position.x + width * 0.99)
        {
            transform.position = new Vector3(transform.position.x - width * 2, transform.position.y, transform.position.z);
        }
    }
}
