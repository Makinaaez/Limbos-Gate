using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGolem : MonoBehaviour
{
    public GameObject die;
    float knocknumb;
    Vector2 diference;
    public bool groundp = false;
    public bool willknock = false;
    public GameObject rune;
    float willlook = 7.8f;
    public bool detectplayer = false;
    public bool canpush = true;
    public float shootcountdown = 6;
    public float stop = 2;
    public GameObject fakeparent;
    public GameObject gun;
    public GameObject bullet;
    bool canfollow = false;
    bool canshoot = false;
    bool canlook = false;
    public bool seecircle = true;
    public GameObject player;
    public Slider HP;
    float secretspeed;
    public float speed;
    public float Damagedealt;
    public float Knockbackdealt;


    private void Awake()
    {
        secretspeed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
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
            if (knocknumb <= 0)
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
                this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.13f, 0.008643925f);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                this.GetComponent<BoxCollider2D>().offset = new Vector2(0.2084092f, 0.008643925f);
            }
            canfollow = true;
            canshoot = true;
        }
        if (canfollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (canlook)
        {
            Vector2 direction = new Vector2(player.transform.position.x - gun.transform.position.x,
            player.transform.position.y - gun.transform.position.y);
            gun.transform.up = direction;
        }
        if (canshoot)
        {
            willlook -= Time.deltaTime;
            shootcountdown -= Time.deltaTime;
        }
        if (shootcountdown <= 0)
        {
            this.GetComponent<Animator>().SetBool("Ischarging", true);
            stop -= Time.deltaTime;
            canshoot = false;
            speed = 0;
                if(stop<=0)
                {
                groundp = true;
                StartCoroutine(shoot());
                }
        }
        if (HP.value <= 0)
        {
            Instantiate(die, transform.position, transform.rotation);
            Instantiate(rune, transform.position, transform.rotation);
            Destroy(fakeparent.gameObject);
        }
        if(willlook >= 0&&detectplayer)
        {
            canlook = true;
        }
        else
        {
            canlook = false;
        }
    }
    IEnumerator shoot()
    {
        this.GetComponent<Animator>().SetBool("Ischarging", false);
        this.GetComponent<Animator>().SetBool("Release", true);
        stop = 2;
        shootcountdown = 6;
        willlook = 7.8f;
        yield return new WaitForSeconds(0.35f);
        if (groundp)
        {
            speed = secretspeed;
            Instantiate(bullet, new Vector3(gun.transform.position.x, gun.transform.position.y, 0), gun.transform.rotation);
            groundp = false;
        }
        yield return new WaitForSeconds(0.7f);
        this.GetComponent<Animator>().SetBool("Release", false);
        speed = secretspeed;
        canshoot = true;
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
