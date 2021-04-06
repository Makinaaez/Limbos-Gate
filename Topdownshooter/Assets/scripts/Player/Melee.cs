using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public bool candisable;
    public float steal = 0.15f;
    public GameObject playerf;
    public float damage;
    public float knockback;
    public float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemie1" || collision.gameObject.tag == "Enemie2" || collision.gameObject.tag == "Enemie3"
          || collision.gameObject.tag == "Enemie4" || collision.gameObject.tag == "Enemie5" || collision.gameObject.tag == "Enemie6" || collision.gameObject.tag == "towerenemie"
          || collision.gameObject.tag == "AEnemie" || collision.gameObject.tag == "Denemie" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Dummy")
        {
                playerf.GetComponent<Player>().HP.value += damage * steal;
            
        }
    }
    private void Update()
    {
        if (candisable)
        {
            candisable = false;
            this.gameObject.SetActive(false);
        }
    }

}
