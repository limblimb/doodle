using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> platformPrefabList;
    public List<float> probabilities;
    private float totalProbability;

    int poolSize = 100;
    int poolCounter;
    private List<GameObject> platformPool;

    public static float spawnPosY;
    public static PlatformGenerator instance;

    

    private void Awake()
    {
        CalculateTotalProbability();

        // экземпл€р класса дл€ использовани€ в других
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
                
        platformPool = new List<GameObject>();

        // создаем и инициализируем объекты пула
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(SelectItem(), transform);
            platform.SetActive(false);
            platformPool.Add(platform);
        }
    }

    void Start()
    {
        // создание стартовых 10 платформ
        Vector2 spawnPos = new Vector2();
        for (int i = 0; i < 10; i++)
        {
            spawnPos.x = Random.Range(-3f, 3f);
            spawnPos.y += Random.Range(1.5f, 3.5f);
            spawnPosY = spawnPos.y; // запоминаем положение по Y последней сгенерированной платформы

            GameObject platform = GetPlatformFromPool();
            platform.transform.position = spawnPos;
            platform.SetActive(true);
            //Instantiate(platformPrefabList[0], spawnPos, Quaternion.identity);
        }
    }

    public GameObject GetPlatformFromPool()
    {
        // ищем неактивный объект в пуле и возвращаем его
        for (int i = poolCounter; i < platformPool.Count; i++)
        {
            if (!platformPool[i].activeInHierarchy)
            {
                poolCounter++;
                return platformPool[i];
            }
        }

        // если все объекты зан€ты, создаем новый
        GameObject newPlatform = Instantiate(SelectItem(), transform);
        platformPool.Add(newPlatform);
        poolCounter++;
        return newPlatform;
    }

    public void ReturnPlatformToPool(GameObject platform)
    {
        platform.SetActive(false);
    }

    private void CalculateTotalProbability()
    {
        totalProbability = 0f;

        // —уммируем все веро€тности
        foreach (float probability in probabilities)
        {
            totalProbability += probability;
        }
    }

    public GameObject SelectItem()
    {
        float randomValue = Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;

        for (int i = 0; i < platformPrefabList.Count; i++)
        {
            cumulativeProbability += probabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                return platformPrefabList[i];
            }
        }

        return platformPrefabList[0];
    }

        public void MakeAnotherOne()
    {
        float newSpawnPosX = Random.Range(-3.5f, 3.5f);
        float newSpawnPosY = Random.Range(spawnPosY + 1.5f, spawnPosY + 3f);
        spawnPosY = newSpawnPosY;

        GameObject platform = GetPlatformFromPool();
        platform.transform.position = new Vector3(newSpawnPosX, newSpawnPosY, 0);
        platform.SetActive(true);
    }



}
