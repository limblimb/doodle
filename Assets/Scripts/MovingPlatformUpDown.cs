using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformUpDown : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 2f;

    private Vector3 initialPosition;
    private float bottomBoundary; 
    private float upBoundary;
    private bool movingUp = true; 

    void Start()
    {
        initialPosition = transform.position;

        // Определение границ экрана
        bottomBoundary = transform.position.y - distance;
        upBoundary = transform.position.y + distance;
        Debug.Log(bottomBoundary + " " + upBoundary);
    }

    void Update()
    {
        // Перемещение платформы
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Проверка границ и изменение направления движения
        if (transform.position.y >= upBoundary)
        {
            movingUp = false;
        }
        else if (transform.position.y <= bottomBoundary)
        {
            movingUp = true;
        }
    }
}
