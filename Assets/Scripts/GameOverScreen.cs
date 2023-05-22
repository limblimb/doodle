using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public Transform cameraPos;
    private float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isAlive)
        {
            transform.position = new Vector3(transform.position.x, cameraPos.position.y - screenHeight, transform.position.z);
        }
        else
        {
            ;
        }
    }
}
