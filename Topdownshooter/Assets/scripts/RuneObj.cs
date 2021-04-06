using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneObj : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite S1;
    public Sprite S2;
    public Sprite S3;
    public Sprite S4;
    public Sprite S5;
    public Sprite S6;
    public Sprite S7;
    public Sprite S8;
    [Header("SelectObject")]
    public float objn = 0;
    void Start()
    {
        objn = Random.Range(1, 9);
        switch (objn)
        {
            case 1:
                this.gameObject.tag = "Rune1";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
                break;
            case 2:
                this.gameObject.tag = "Rune2";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
                break;
            case 3:
                this.gameObject.tag = "Rune3";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
                break;
            case 4:
                this.gameObject.tag = "Rune4";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
                break;
            case 5:
                this.gameObject.tag = "Rune5";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
                break;
            case 6:
                this.gameObject.tag = "Rune6";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
                break;
            case 7:
                this.gameObject.tag = "Rune7";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
                break;
            case 8:
                this.gameObject.tag = "Rune8";
                this.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (objn)
            {
                case 1:
                    collision.gameObject.GetComponent<Player>().HP.maxValue += 50;
                    collision.gameObject.GetComponent<Player>().HP.value += 50;
                    Destroy(this.gameObject);
                    break;
                case 2:
                    collision.gameObject.GetComponent<Player>().Stamina.maxValue += 75;
                    collision.gameObject.GetComponent<Player>().Stamina.value += 75;
                    Destroy(this.gameObject);
                    break;
                case 3:
                    collision.gameObject.GetComponent<Player>().sword.GetComponent<Melee>().steal += 0.25f;
                    Destroy(this.gameObject);
                    break;
                case 4:
                    collision.gameObject.GetComponent<Player>().sword.GetComponent<Melee>().damage += 100;
                    Destroy(this.gameObject);
                    break;
                case 5:
                    collision.gameObject.GetComponent<Player>().bullet.GetComponent<Bullet>().damage += 25;
                    Destroy(this.gameObject);
                    break;
                case 6:
                    collision.gameObject.GetComponent<Player>().runSpeed+= 0.5f;
                    Destroy(this.gameObject);
                    break;
                case 7:
                    collision.gameObject.GetComponent<Player>().dashspeed += 10;
                    Destroy(this.gameObject);
                    break;
                case 8:
                    collision.gameObject.GetComponent<Player>().regenscountrem -= 2.5f;
                    collision.gameObject.GetComponent<Player>().regenscount -= 2.5f;
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (objn)
            {
                case 1:
                    collision.gameObject.GetComponent<Player>().HP.maxValue += 50;
                    collision.gameObject.GetComponent<Player>().HP.value += 50;
                    Destroy(this.gameObject);
                    break;
                case 2:
                    collision.gameObject.GetComponent<Player>().Stamina.maxValue += 75;
                    collision.gameObject.GetComponent<Player>().Stamina.value += 75;
                    Destroy(this.gameObject);
                    break;
                case 3:
                    collision.gameObject.GetComponent<Player>().sword.GetComponent<Melee>().steal += 0.25f;
                    Destroy(this.gameObject);
                    break;
                case 4:
                    collision.gameObject.GetComponent<Player>().sword.GetComponent<Melee>().damage += 100;
                    Destroy(this.gameObject);
                    break;
                case 5:
                    collision.gameObject.GetComponent<Player>().bullet.GetComponent<Bullet>().damage += 25;
                    Destroy(this.gameObject);
                    break;
                case 6:
                    collision.gameObject.GetComponent<Player>().runSpeed += 0.5f;
                    Destroy(this.gameObject);
                    break;
                case 7:
                    collision.gameObject.GetComponent<Player>().dashspeed += 10;
                    Destroy(this.gameObject);
                    break;
                case 8:
                    collision.gameObject.GetComponent<Player>().regenscountrem -= 2.5f;
                    collision.gameObject.GetComponent<Player>().regenscount -= 2.5f;
                    Destroy(this.gameObject);
                    break;
            }
        }

    }
}
