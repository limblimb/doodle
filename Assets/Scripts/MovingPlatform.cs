using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f; // �������� ����������� ���������

    private Vector3 initialPosition;
    private float leftBoundary; // ����� ������� ������
    private float rightBoundary; // ������ ������� ������
    private bool movingRight = true; // ����, ����������� ����������� �������� ���������

    void Start()
    {
        initialPosition = transform.position;

        // ����������� ������ ������
        leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        // ����������� ��������� ����� ��� ������
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // �������� ������ � ��������� ����������� ��������
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
