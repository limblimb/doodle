using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool moveSwitcher;
    float xRange;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xRange && !moveSwitcher)
        {
            transform.Translate(new Vector3(1, 0, 0));
            if (transform.position.x >=4)
            {
                moveSwitcher = true;
            }
        }
        if (transform.position.x > -xRange && moveSwitcher)
        {
            transform.Translate(new Vector3(1, 0, 0));
            if (transform.position.x <= -4)
            {
                moveSwitcher = false;
            }
        }
        
        
        
    }
}
