using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEnemyDetector : MonoBehaviour
{
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 0.9f, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // add score
            GameManager._instance._time += 5;
            enemy.GetComponent<SpriteRenderer>().flipY = true;
            enemy.GetComponent<Transform>().rotation.Set(0, 0, 0, 0);
            enemy.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
