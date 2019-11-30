using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    // trigger to destroy platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destroyer"))
        {
            gameObject.SetActive(false);
        }
    }
}
