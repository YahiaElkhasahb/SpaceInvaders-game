using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombspowner : MonoBehaviour
{

    public float min_x = -11.3f, max_x = 11.3f;

    public GameObject enemyPrefab;

    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {

        float pos_x = Random.Range(min_x, max_x);
        Vector3 temp = transform.position;
        temp.x = pos_x;



            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
      
        //else
        //{

        //    Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));

        //}

        Invoke("SpawnEnemies", timer);

    }



}