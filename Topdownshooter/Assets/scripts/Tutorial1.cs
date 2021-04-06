using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    public bool d=false;
    private void Update()
    {
        if (d)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
