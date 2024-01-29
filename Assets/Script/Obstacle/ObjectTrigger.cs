using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private GameObject myObject;
    private Obstacle myObstacle;

    public float min = 0f;
    public float max = 0f;

    private void Start()
    {
        myObstacle = GetComponent<Obstacle>();
        myObject = myObstacle.choiceObject;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (myObstacle.choice == ModeChoice.Mode.Hide)
        {
            if (myObstacle.choiceObject.activeSelf == false)
                myObstacle.choiceObject.SetActive(true);
            myObstacle.triggerObject.SetActive(false);
        }

        if (myObstacle.choice == ModeChoice.Mode.Drop ||
            myObstacle.choice == ModeChoice.Mode.Fly)
        {
            if (myObstacle.choiceObject.activeSelf == false)
                Invoke("WaitDrop", myObstacle.wait);
            myObstacle.triggerObject.SetActive(false);
        }

        if (myObstacle.choice == ModeChoice.Mode.Rain)
        {
            if (myObstacle.choiceObject.activeSelf == false)
                myObstacle.choiceObject.SetActive(true);

            InvokeRepeating("MakeRain", 0, 0.5f);

            myObstacle.triggerObject.SetActive(false);
        }
    }

    public void MakeRain()
    {
        float x = Random.Range(min, max);// 값조절
        myObstacle.choiceObject.transform.position = new Vector3(x, 5f, 0);
        Instantiate(myObstacle.choiceObject);
    }

    public void WaitDrop()
    {
        myObstacle.choiceObject.SetActive(true);
    }
}
