using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChoice : MonoBehaviour
{
    public Mode choice;
    public GameObject choiceObject;
    public GameObject triggerObject;
    public float gravity;
    public float wait = 0f;
    private Rigidbody2D _rigidbody2D;
    public bool oneTime = false;


    public enum Mode
    {
        Fix = 0,
        Drop,
        RandomRain,
        Rain,
        Fly,
        Hide
    }

    protected virtual void Start()
    {
        switch (choice)
        {
            case Mode.Fix:
                FixMode();
                triggerObject = null;
                break;
            case Mode.Drop:
                DropMode();
                break;
            case Mode.RandomRain:
                RandomRainMode();
                break;
            case Mode.Rain:
                RainMode();
                break;
            case Mode.Fly:
                FlyMode();
                break;
            case Mode.Hide:
                HideMode();
                break;
        }
    }

    public void FixMode()
    {
        choiceObject.SetActive(true);

        _rigidbody2D = choiceObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void DropMode()
    {
        choiceObject.SetActive(false);

        _rigidbody2D = choiceObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = gravity;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;        
    }

    public void RandomRainMode()
    {
        _rigidbody2D = choiceObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = gravity;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void RainMode()
    {
        _rigidbody2D = choiceObject.GetComponentInChildren<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = gravity;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void FlyMode()
    {
        choiceObject.SetActive(false);

        _rigidbody2D = choiceObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = gravity;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void HideMode()
    {
        choiceObject.SetActive(false);

        _rigidbody2D = choiceObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }
}
