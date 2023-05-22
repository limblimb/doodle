using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f; // Скорость перемещения платформы

    private Vector3 initialPosition;
    private float leftBoundary; // Левая граница экрана
    private float rightBoundary; // Правая граница экрана
    private bool movingRight = true; // Флаг, указывающий направление движения платформы

    void Start()
    {
        initialPosition = transform.position;

        // Определение границ экрана
        leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        // Перемещение платформы влево или вправо
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Проверка границ и изменение направления движения
        if (transform.position.x >= rightBoundary)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftBoundary)
        {
            movingRight = true;
        }
    }
}
