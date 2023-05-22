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

        // ����������� ������ ������
        bottomBoundary = transform.position.y - distance;
        upBoundary = transform.position.y + distance;
        Debug.Log(bottomBoundary + " " + upBoundary);
    }

    void Update()
    {
        // ����������� ���������
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // �������� ������ � ��������� ����������� ��������
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
