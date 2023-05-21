using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        // ���������, ����� �� �������� �� ������� ������
        if (!render.isVisible)
        {
            Wrap();
        }
    }

    private void Wrap()
    {
        // �������� ������� ������ � ������� �����������
        float screenWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        float offset = transform.localScale.x * 0.5f;

        // ���������� �������� �� ��������������� ������� ������
        if (transform.position.x > 0f)
        {
            transform.position = new Vector3(-screenWidth * 0.5f - offset, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(screenWidth * 0.5f + offset, transform.position.y, transform.position.z);
        }
    }
}