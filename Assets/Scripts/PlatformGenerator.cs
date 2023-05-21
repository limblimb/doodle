using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 spawnPos = new Vector2();

        for (int i =0; i<10; i++)
        {
            spawnPos.x = Random.Range(-3f, 3f);
            spawnPos.y += Random.Range(1.5f, 3.5f);

            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
