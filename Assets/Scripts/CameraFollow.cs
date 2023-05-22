using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform gameOver;
    public float smoothSpeed = 1f;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - gameOver.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isAlive)
        {
            if (player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            }
        }
        else
        {
            Vector3 desiredPosition = gameOver.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

    }
}
