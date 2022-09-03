using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCopyJelly : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "JellyPrefab(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "JellyPrefab(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }

}    

