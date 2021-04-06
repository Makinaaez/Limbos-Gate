using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool animate = false;
    public Animator o;

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            o.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Mele")
        {
            animate = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
