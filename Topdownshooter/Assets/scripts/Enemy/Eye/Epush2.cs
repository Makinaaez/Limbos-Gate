using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epush2 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            player.GetComponent<EyeEnemy>().canpush = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            player.GetComponent<EyeEnemy>().canpush = true;
        }

    }
}
