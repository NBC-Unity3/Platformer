using System.Collections;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody;

    public float delta = 3.0f;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 pos = player.transform.position;
        pos.y = 4.0f;
        pos.x += 3 + delta * Mathf.Sin(Time.time * speed);

        transform.position = pos;
    }


}
