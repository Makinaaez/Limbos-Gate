using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallA : MonoBehaviour

{
    public GameObject dead;
    float knocknumb;
    Vector2 diference;
    public bool willknock = false;
    public bool demon=false;
    public GameObject boss;
    public bool canpush= true;
    public GameObject gun;
    public GameObject bullet;
    public bool canshoot=true;
    public GameObject player;
    public Slider HP;
    public float speed;
    public float Damagedealt;
    public float Knockbackdealt;

    private void Awake()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }
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
        if (player.GetComponent<Player>().HP.value <= 0)
        {
            Destroy(this.gameObject);
        }
        if (gameObject.transform.position.x >= player.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (willknock)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            knocknumb -= Time.deltaTime;
            GetComponent<Rigidbody2D>().AddForce(diference.normalized * 5, ForceMode2D.Impulse);
            if (knocknumb <= 0)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                knocknumb = 0;
                willknock = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            Vector2 direction = new Vector2(player.transform.position.x - gun.transform.position.x,
            player.transform.position.y - gun.transform.position.y);
            gun.transform.up = direction;

        if (canshoot)
        {
            StartCoroutine(shoot());
        }
        if(boss.GetComponent<AngelBoss>().HP.value <= 2500&&!demon)
        {
            Destroy(this.gameObject);
        }
        if (boss.GetComponent<AngelBoss>().HP.value <= 0)
        {
            Instantiate(dead, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (HP.value <= 0)
        {
            Instantiate(dead, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    IEnumerator shoot()
    {
        canshoot = false;
        yield return new WaitForSeconds(1);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(2);
        canshoot = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("nemie"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.gameObject.tag.Contains("Player"))
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
