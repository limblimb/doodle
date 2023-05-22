using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformGenerator platformPooler;

    private void Awake()
    {
        platformPooler = FindAnyObjectByType<PlatformGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dead Zone"))
        {
            PlatformGenerator.instance.MakeAnotherOne();
            platformPooler.ReturnPlatformToPool(gameObject);
        }
    }
}
