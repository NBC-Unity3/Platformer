using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCollision : MonoBehaviour
{
    public GameObject Trigger;
    public GameObject Obstacle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeRepeating("MakeObstacleRain", 0, 0.5f);
        Trigger.SetActive(false);
    }

    void MakeObstacleRain()
    {
        Instantiate(Obstacle);
    }
}
