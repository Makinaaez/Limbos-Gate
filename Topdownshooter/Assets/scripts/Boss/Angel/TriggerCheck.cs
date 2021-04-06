using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public bool Is=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Is = true;
        }
        if (collision.gameObject.tag == "Untagged")
        {
            Is = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Is = true;
        }
        if (collision.gameObject.tag == "Untagged")
        {
            Is = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Is = false;
        }
        if (collision.gameObject.tag == "Untagged")
        {
            Is = false;
        }
    }
}
