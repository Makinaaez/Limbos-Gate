using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpin : MonoBehaviour
{
    public GameObject die;
    float knocknumb;
    Vector2 diference;
    public bool willknock = false;
    public GameObject caller;
    public bool detectplayer = false;
    public bool canpush = true;
    public float shootcountdown = 2.5f;
    public GameObject fakeparent;
    public GameObject Spin;
    bool canfollow = false;
    public bool canspin = false;
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

        if (collision.gameObject.tag == "Bullet" && this.gameObject.tag == "Enemie4")
        {
            HP.value -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        if (collision.gameObject.tag == "Mele" && this.gameObject.tag == "Enemie4")
        {
            willknock = true;
            HP.value -= collision.gameObject.GetComponent<Melee>().damage;
            diference = transform.position - collision.transform.position;
            knocknumb = collision.gameObject.GetComponent<Melee>().knockback;
        }
    }
    private void Update()
    {
        if (willknock && this.gameObject.tag == "Enemie4")
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
            canspin = true;
        }
        if (canfollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
            if (canspin)
            {
            shootcountdown -= Time.deltaTime;
            if(shootcountdown <= 0.7)
            {
                Instantiate(caller, new Vector3(transform.position.x+0.1f, transform.position.y-0.3f, transform.position.z), transform.rotation);
                if (shootcountdown <= 0.3)
                {
                    this.GetComponent<Animator>().SetBool("raise", true);
                }
            }
            if (shootcountdown <= 0)
            {
                canspin = false;
                StartCoroutine(shoot());
            }
        }
        if (HP.value <= 0)
        {
            Instantiate(die, transform.position, transform.rotation);
            Destroy(fakeparent.gameObject);
        }
    }
    IEnumerator shoot()
    {
        this.GetComponent<Animator>().SetBool("raise", false);
        this.gameObject.tag = "Spin";
        speed = 1.2f;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        HP.gameObject.SetActive(false);
        Spin.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(3);
        shootcountdown = 2.5f;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;
        HP.gameObject.SetActive(true);
        Spin.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        speed = secretspeed;
        this.gameObject.tag = "Enemie4";
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
