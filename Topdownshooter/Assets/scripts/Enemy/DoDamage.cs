using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float Hitdam;
    public float Damagedealt;
    public float Knockbackdealt;
    bool candam=true;
    GameObject p;

    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().HP.value -= Hitdam;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&& this.gameObject.tag != "ASword1")
        {
            collision.gameObject.GetComponent<Player>().HP.value -= Hitdam;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag != "ASword1"&&candam)
        {
            p = collision.gameObject;
            StartCoroutine(deal());
        }
    }
    IEnumerator deal()
    {
        candam = false;
        p.gameObject.GetComponent<Player>().HP.value -= Damagedealt;
        yield return new WaitForSeconds(1);
        candam=true;
    }
}
