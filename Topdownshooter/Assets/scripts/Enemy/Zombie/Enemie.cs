using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemie : MonoBehaviour
{
    public GameObject die;
    public float knocknumb;
    public Vector2 diference;
    public bool willknock = false;
    public GameObject fakedad;
    public bool detectplayer=false;
    bool canfollow = false;
    public GameObject player;
    public Slider HP;
    public float speed;
    public float Damagedealt;
    public float Knockbackdealt;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Bullet")
        {
            HP.value -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        if (collision.gameObject.tag == "Mele")
        {
            willknock = true;
            HP.value -= collision.gameObject.GetComponent<Melee>().damage;
            diference = transform.position - collision.transform.position;
            knocknumb = collision.gameObject.GetComponent<Melee>().knockback;
        }
    }
    private void Update()
    {
        
            if (willknock)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            detectplayer = false;
            canfollow = false;
            knocknumb -= Time.deltaTime;
            GetComponent<Rigidbody2D>().AddForce(diference.normalized * 5, ForceMode2D.Impulse);
            if (knocknumb <=0)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                detectplayer = true;
                canfollow = true;
                knocknumb = 0;
                willknock = false;
            }
        }
        if (detectplayer)
        {
            if (gameObject.transform.position.x >= player.transform.position.x)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            canfollow = true;
        }
        if (canfollow == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(HP.value <= 0)
        {
            Instantiate(die, transform.position, transform.rotation);
            Destroy(fakedad.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("nemie"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.gameObject.tag == "wall")
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
