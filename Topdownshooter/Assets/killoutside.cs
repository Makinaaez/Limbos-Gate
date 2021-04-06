using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killoutside : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemie2")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemie2")
        {
            Destroy(collision.gameObject);
        }
    }
}
