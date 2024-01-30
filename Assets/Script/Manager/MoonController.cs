using System.Collections;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody;

    public float height = 5.0f;
    public float distance = 1.0f;
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
        pos.y = height;
        pos.x += distance + delta * Mathf.Sin(Time.time * speed);

        transform.position = pos;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.name == "Clear")
        {
            Destroy(gameObject);
        }
    }

}
