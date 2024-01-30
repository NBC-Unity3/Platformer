using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public bool isVertical = false;
    public float rightMax = 0;
    public float leftMax = 0;
    public float upMax = 0;
    public float downMax = 0;
    public float speed = 3.0f;

    private Vector2 currentPosition;

    private Vector2 direction = new Vector2(1.0f, 1.0f);


    void Awake()
    {
        currentPosition = transform.position;
        if (isVertical) direction = new Vector2(0, 1.0f);
        else direction = new Vector2(1.0f, 0);
    }

    void Start()
    {
        rightMax += currentPosition.x;
        leftMax += currentPosition.x;
        upMax += currentPosition.y;
        downMax += currentPosition.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPosition += Time.deltaTime * speed * direction;

        if (currentPosition.x >= rightMax || currentPosition.x <= leftMax) direction.x *= -1;
        else if (currentPosition.y >= upMax || currentPosition.y <= downMax) direction.y *= -1;

        transform.position = currentPosition;
    }
}
