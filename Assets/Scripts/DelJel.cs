using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelJel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Clone")
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}