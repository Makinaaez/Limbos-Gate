using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchplayer : MonoBehaviour
{
    public bool playerhere = false;
    public GameObject isplay;
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.SetActive(true);
            playerhere= true;
            isplay = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.SetActive(true);
            playerhere = true;
            isplay = collision.gameObject;
        }
    }
}
