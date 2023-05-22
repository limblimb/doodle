using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> platformPrefabList;
    public List<float> probabilities;
    private float totalProbability;
    public string DontRepeatTag = "Cracking Platform"; // Тег объекта, который нужно исключить из повторяющегося добавления
    private GameObject lastObjectAdded; // Последний добавленный объект

    int poolSize = 33;
    int poolCounter;
    private List<GameObject> platformPool;

    public static float spawnPosY;
    public static PlatformGenerator instance;

    private void Awake()
    {
        CalculateTotalProbability();

        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
                
        platformPool = new List<GameObject>();
        lastObjectAdded = null;
        // Создание и инициализация объектов пула
        for (int i = 0; i < poolSize; i++)
        {
            GameObject chosenPlatform = SelectItem();
            // Здесь проверяется, чтобы Cracking Platform не появлялась два раза подряд
            if (lastObjectAdded != null)
            {
                if (lastObjectAdded.CompareTag(chosenPlatform.tag) && lastObjectAdded.CompareTag(DontRepeatTag))
                {
                    while (chosenPlatform.tag == lastObjectAdded.tag)
                    {
                        chosenPlatform = SelectItem();
                    }
                }
            }
            lastObjectAdded = chosenPlatform;
            GameObject platform = Instantiate(chosenPlatform, transform);
            platform.SetActive(false);
            platformPool.Add(platform);
        }
    }

    void Start()
    {
        // Создание стартовых 10 платформ
        Vector2 spawnPos = new Vector2();
        for (int i = 0; i < 10; i++)
        {
            spawnPos.x = Random.Range(-3f, 3f);
            spawnPos.y += Random.Range(1.5f, 3.5f);
            spawnPosY = spawnPos.y; // запоминаем положение по Y последней сгенерированной платформы

            GameObject platform = GetPlatformFromPool();
            platform.transform.position = spawnPos;
            platform.SetActive(true);
        }
    }

    public GameObject GetPlatformFromPool()
    {
        // Поиск неактивного объекта в пуле
        for (int i = poolCounter; i < platformPool.Count; i++)
        {
            if (!platformPool[i].activeInHierarchy)
            {
                poolCounter++;
                return platformPool[i];
            }
        }

        // Если все объекты заняты, создаем новый
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

        // Суммируем все вероятности
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
        float newSpawnPosY = Random.Range(spawnPosY + 1.5f, spawnPosY + 5f);
        spawnPosY = newSpawnPosY;

        GameObject platform = GetPlatformFromPool();
        platform.transform.position = new Vector3(newSpawnPosX, newSpawnPosY, 0);
        platform.SetActive(true);
    }



}
