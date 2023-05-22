using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> platformPrefabList;
    public List<float> probabilities;
    private float totalProbability;
    public string DontRepeatTag = "Cracking Platform"; // ��� �������, ������� ����� ��������� �� �������������� ����������
    private GameObject lastObjectAdded; // ��������� ����������� ������

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
        // �������� � ������������� �������� ����
        for (int i = 0; i < poolSize; i++)
        {
            GameObject chosenPlatform = SelectItem();
            // ����� �����������, ����� Cracking Platform �� ���������� ��� ���� ������
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
        // �������� ��������� 10 ��������
        Vector2 spawnPos = new Vector2();
        for (int i = 0; i < 10; i++)
        {
            spawnPos.x = Random.Range(-3f, 3f);
            spawnPos.y += Random.Range(1.5f, 3.5f);
            spawnPosY = spawnPos.y; // ���������� ��������� �� Y ��������� ��������������� ���������

            GameObject platform = GetPlatformFromPool();
            platform.transform.position = spawnPos;
            platform.SetActive(true);
        }
    }

    public GameObject GetPlatformFromPool()
    {
        // ����� ����������� ������� � ����
        for (int i = poolCounter; i < platformPool.Count; i++)
        {
            if (!platformPool[i].activeInHierarchy)
            {
                poolCounter++;
                return platformPool[i];
            }
        }

        // ���� ��� ������� ������, ������� �����
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

        // ��������� ��� �����������
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
