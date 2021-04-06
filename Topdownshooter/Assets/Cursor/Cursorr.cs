using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorr : MonoBehaviour
{
    public bool can = true;
    public Sprite Or;
    public Sprite r1;
    public Sprite r2;
    public Sprite r3;
    public Sprite r4;
    public Sprite r5;
    public Sprite r6;
    public Sprite r7;
    public Sprite r8;
    void Update()
    {
        if (can)
        {
            Cursor.visible = false;
            Vector2 cp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cp;
        }
        if (!can)
        {
            Cursor.visible = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rune1")
        {
            GetComponent<SpriteRenderer>().sprite = r1;
        }
        if (collision.gameObject.tag == "Rune2")
        {
            GetComponent<SpriteRenderer>().sprite = r2;
        }
        if (collision.gameObject.tag == "Rune3")
        {
            GetComponent<SpriteRenderer>().sprite = r3;
        }
        if (collision.gameObject.tag == "Rune4")
        {
            GetComponent<SpriteRenderer>().sprite = r4;
        }
        if (collision.gameObject.tag == "Rune5")
        {
            GetComponent<SpriteRenderer>().sprite = r5;
        }
        if (collision.gameObject.tag == "Rune6")
        {
            GetComponent<SpriteRenderer>().sprite = r6;
        }
        if (collision.gameObject.tag == "Rune7")
        {
            GetComponent<SpriteRenderer>().sprite = r7;
        }
        if (collision.gameObject.tag == "Rune8")
        {
            GetComponent<SpriteRenderer>().sprite = r8;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rune1"|| collision.gameObject.tag == "Rune2"|| collision.gameObject.tag == "Rune3" || collision.gameObject.tag == "Rune4"||
            collision.gameObject.tag == "Rune5" || collision.gameObject.tag == "Rune6" || collision.gameObject.tag == "Rune7" || collision.gameObject.tag == "Rune8")
        {
            GetComponent<SpriteRenderer>().sprite = Or;
        }
    }
}
