using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarrier : Item
{
    [SerializeField]
    GameObject barrierObject;

    private void Start()
    {
        barrierObject.SetActive(false);
    }

    public override void ConsumeItem(GameObject player) 
    {
        barrierObject.SetActive(true);
    }
}
