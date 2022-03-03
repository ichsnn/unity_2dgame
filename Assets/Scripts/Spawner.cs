using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float interval;

    private float time = 0f;
    private float randTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        randTime = Random.Range(1f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= randTime)
        {
            time = 0f;
            randTime = Random.Range(1f, interval);
            var obj = Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
