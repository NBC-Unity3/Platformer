using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private GameObject myObject;
    private Obstacle myObstacle;

    public Transform min;
    public Transform max;

    public float InstanseSpeed; 


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
            Destroy(myObstacle.triggerObject);
        }

        if (myObstacle.choice == ModeChoice.Mode.Drop ||
            myObstacle.choice == ModeChoice.Mode.Fly)
        {
            if (myObstacle.choiceObject.activeSelf == false)
                Invoke("WaitDrop", myObstacle.wait);            
        }

        if (myObstacle.choice == ModeChoice.Mode.RandomRain)
        {
            if (myObstacle.choiceObject.activeSelf == false)
                myObstacle.choiceObject.SetActive(true);

            InvokeRepeating("MakeRandomRain", 0, InstanseSpeed);

            myObstacle.triggerObject.SetActive(false);
        }

        if (myObstacle.choice == ModeChoice.Mode.Rain)
        {
            if (myObstacle.choiceObject.activeSelf == false)
                myObstacle.choiceObject.SetActive(true);

            if (myObstacle.oneTime == false)
                InvokeRepeating("MakeRain", myObstacle.wait, InstanseSpeed);
            if (myObstacle.oneTime == true)
                Invoke("MakeRain", myObstacle.wait);


            myObstacle.triggerObject.SetActive(false);
            //test
        }
    }

    public void MakeRandomRain()
    {
        float x = Random.Range(min.position.x,max.position.x);// 값조절
        myObstacle.choiceObject.transform.position = new Vector3(x, min.position.y, 0);
        Instantiate(myObstacle.choiceObject);
    }

    public void MakeRain()
    {
        myObstacle.choiceObject.transform.position = new Vector3(min.position.x, min.position.y, 0);
        Instantiate(myObstacle.choiceObject);
    }

    public void WaitDrop()
    {
        myObstacle.choiceObject.SetActive(true);
        Destroy(myObstacle.triggerObject);
    }
}
