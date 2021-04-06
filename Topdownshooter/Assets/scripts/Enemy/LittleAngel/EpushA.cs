using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpushA : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            player.GetComponent<SniperEnemie>().canpush = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            player.GetComponent<SniperEnemie>().canpush = true;
        }

    }
}
