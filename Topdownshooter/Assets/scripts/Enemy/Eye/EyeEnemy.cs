using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeEnemy : MonoBehaviour
{
    public GameObject die;
    public float knocknumb;
    public Vector2 diference;
    public bool willknock = false;
    public GameObject rune;
    bool s1 = true;
    bool s2 = true;
    bool s3 = true;
    bool s4 = true;
    public bool detectplayer = false;
    public LineRenderer laser;
    public bool canpush = true;
    float shootcountdown = 3;
    float stop = 3;
    public GameObject fakeparent;
    public GameObject gun;
    public GameObject bullet;
    bool canfollow = false;
    bool canshoot = true;
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
            canlook = true;
            canfollow = true;
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
            if (canshoot)
            {
                shootcountdown -= Time.deltaTime;
            }
        }
        if (shootcountdown <= 0)
        {
            this.GetComponent<Animator>().SetBool("ischarging", true);
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, player.transform.position);
            stop -= Time.deltaTime;
            canshoot = false;
            speed = 0;
                if(stop<=0)
            {
                laser.SetPosition(0, Vector3.zero);
                laser.SetPosition(1, Vector3.zero);
                StartCoroutine(shoot());
                }
        }
        if (HP.value <= 0)
        {
            Instantiate(die, transform.position, transform.rotation);
            Instantiate(rune, transform.position, transform.rotation);
            Destroy(fakeparent.gameObject);
        }
    }
    IEnumerator shoot()
    {
        stop = 3;
        shootcountdown = 3;
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(1);
        if (s1)
        {
            s1 = false;
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
        yield return new WaitForSeconds(1);
        if (s2)
        {
            s2 = false;
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
        yield return new WaitForSeconds(1);
        if (s3)
        {
            s3 = false;
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
        yield return new WaitForSeconds(1);
        if (s4)
        {
            s4 = false;
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
        this.GetComponent<Animator>().SetBool("ischarging", false);
        speed = secretspeed;
        yield return new WaitForSeconds(1);
        canshoot = true;
        s1 = true;
        s2 = true;
        s3 = true;
        s4 = true;
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
