using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public GameObject Enemie;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemie.gameObject.GetComponent<EnemieTurret>().canfollow = false;
            Enemie.gameObject.GetComponent<EnemieTurret>().canrotate = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemie.gameObject.GetComponent<EnemieTurret>().canfollow = true;
            Enemie.gameObject.GetComponent<EnemieTurret>().canrotate = false;

        }

    }
}
