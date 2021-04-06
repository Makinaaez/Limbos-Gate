using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public GameObject Self;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Self.GetComponent<SniperEnemie>().canrun= true;
        }
            
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Self.GetComponent<SniperEnemie>().canrun = true;
        }
    }
}
