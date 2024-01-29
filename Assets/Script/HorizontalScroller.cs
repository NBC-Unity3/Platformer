using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(SpriteRenderer))]
public class HorizontalScroller : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 1.0f;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    float width = 0;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        width = ((float)spriteRenderer.sprite.textureRect.width * transform.localScale.x) / spriteRenderer.sprite.pixelsPerUnit;
    }
    private void FixedUpdate()
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
