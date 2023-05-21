using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead Zone"))
        {
            float spawnPosX = Random.Range(-2f, 4f);
            float spawnPosY = Random.Range(transform.position.y + 25f, transform.position.y + 26.5f);

            transform.position = new Vector3(spawnPosX, spawnPosY, 0);
        }
    }

    
}
