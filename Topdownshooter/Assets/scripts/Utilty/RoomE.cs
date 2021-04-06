using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomE : MonoBehaviour
{
    bool can=false;
    public float en;
    public GameObject door;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemie1"|| collision.gameObject.tag == "Enemie2"|| collision.gameObject.tag == "Enemie3"||
            collision.gameObject.tag == "Enemie4" || collision.gameObject.tag == "Enemie5" || collision.gameObject.tag == "Enemie6"
            || collision.gameObject.tag == "Spin" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "towerenemie")
        {
            en += 1;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemie1" || collision.gameObject.tag == "Enemie2" || collision.gameObject.tag == "Enemie3" ||
            collision.gameObject.tag == "Enemie4" || collision.gameObject.tag == "Enemie5" || collision.gameObject.tag == "Enemie6"
            || collision.gameObject.tag == "Spin" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "towerenemie")
        {
            en -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ora());
        if (can)
        {
            if (en == 0)
            {
                door.GetComponent<Animator>().enabled = true;
                door.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
    IEnumerator ora()
    {
        yield return new WaitForSeconds(1);
        can = true;
    }
}
