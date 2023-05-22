using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float screenWidth;

    private void Start()
    {
        // �������� ������ ������ � ������� �����������
        float screenDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenDistance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenDistance));
        screenWidth = Mathf.Abs(rightmost.x - leftmost.x);
    }

    private void Update()
    {
        // �������� ������� ��������� � ������� �����������
        Vector3 currentPosition = transform.position;

        // ���������, ����� �� �������� �� ������� ������
        if (currentPosition.x > screenWidth / 2)
        {
            // ���������� ��������� �� ��������������� ������� ������
            transform.position = new Vector3(-screenWidth / 2, currentPosition.y, currentPosition.z);
        }
        else if (currentPosition.x < -screenWidth / 2)
        {
            // ���������� ��������� �� ��������������� ������� ������
            transform.position = new Vector3(screenWidth / 2, currentPosition.y, currentPosition.z);
        }
    }
}