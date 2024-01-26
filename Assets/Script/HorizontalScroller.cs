using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HorizontalScroller : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 1.0f;
    Vector2 moveDirection;

    private void Awake()
    {
        InputController controller = GameObject.FindWithTag("Player").GetComponent<InputController>();
        controller.OnMoveEvent += SetMoveDirection;
    }

    private void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
    }

    void ApplyMovement(Vector2 moveDirection) 
    {
        transform.position -= new Vector3(moveDirection.x * scrollSpeed * Time.fixedDeltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);

        // 1920x1080 images has 19.2 width (in PixelPerUnit 100)
        if (transform.position.x < Camera.main.transform.position.x - 18.0f)
        {
            transform.position = new Vector3(transform.position.x + 38.4f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > Camera.main.transform.position.x + 18.0f) 
        {
            transform.position = new Vector3(transform.position.x - 38.4f, transform.position.y, transform.position.z);
        }
    }
}
