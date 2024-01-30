using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    public Transform parent;

    private Sprite[] sprites;
    [SerializeField] private float minTime = 2;
    [SerializeField] private float maxTime = 4;
    private float cooltime;
    void Start()
    {
        StartCoroutine(SpawnNag()); 
        sprites = Resources.LoadAll<Sprite>("Images/TIL");
    }

    IEnumerator SpawnNag() {
        float cooltime = Random.Range(minTime, maxTime);
        
        while(true)
        {
            yield return new WaitForSeconds(cooltime);

            GameObject nag = Instantiate(prefab, parent);

            nag.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
            
            nag.AddComponent<PolygonCollider2D>();
            nag.transform.position = transform.position;
        }
    }

    private void CalcForce()
    {
        /*
            바닥 y값: -4
            gravity : 9.81f
            t^2 = distance * 2 / gravity

        */


        Vector2 pos = transform.position;
        Vector2 dest = player.transform.position;

        // 거리 = 속력 x 시간
        
    }
}
