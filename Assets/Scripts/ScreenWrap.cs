using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float screenWidth;

    private void Start()
    {
        // Получаем ширину экрана в мировых координатах
        float screenDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenDistance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenDistance));
        screenWidth = Mathf.Abs(rightmost.x - leftmost.x);
    }

    private void Update()
    {
        // Получаем позицию персонажа в мировых координатах
        Vector3 currentPosition = transform.position;

        // Проверяем, вышел ли персонаж за пределы экрана
        if (currentPosition.x > screenWidth / 2)
        {
            // Перемещаем персонажа на противоположную сторону экрана
            transform.position = new Vector3(-screenWidth / 2, currentPosition.y, currentPosition.z);
        }
        else if (currentPosition.x < -screenWidth / 2)
        {
            // Перемещаем персонажа на противоположную сторону экрана
            transform.position = new Vector3(screenWidth / 2, currentPosition.y, currentPosition.z);
        }
    }
}