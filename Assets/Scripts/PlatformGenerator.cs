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
            spawnPos.x = Random.Range(-2f, 2f);
            spawnPos.y += Random.Range(2f, 4f);

            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
