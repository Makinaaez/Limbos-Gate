using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperEnemie : MonoBehaviour

{
    public GameObject die;
    public Vector2 diference;
    public float knocknumb;
    public bool willknock = false;
    public bool canrun = false;
    float sec;
    public bool lasercan = false;
    public bool detectplayer = false;
    public LineRenderer laser;
    public bool canpush= true;
    public GameObject fakeparent;
    public GameObject gun;
    public GameObject bullet;
    public bool canshoot=true;
    public bool canlook=false;
    public GameObject player;
    public Slider HP;
    public float speed;
    public float Damagedealt;
    public float Knockbackdealt;

    private void Start()
    {
        sec = Random.Range(1, 5);
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
        if (willknock)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            detectplayer = false;
            knocknumb -= Time.deltaTime;
            GetComponent<Rigidbody2D>().AddForce(diference.normalized * 5, ForceMode2D.Impulse);
            if (knocknumb <= 0)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                detectplayer = true;
                knocknumb = 0;
                willknock = false;
            }
        }
        if (canrun)
        {
            this.GetComponent<Animator>().SetBool("Canrun",true);
            transform.position = Vector2.MoveTowards(transform.position, GetComponent<SniperEnemie>().player.transform.position, -1 * GetComponent<SniperEnemie>().speed * Time.deltaTime);
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
            sec -= Time.deltaTime;
            canlook = true;
        }
        if (canlook)
        {
            Vector2 direction = new Vector2(player.transform.position.x - gun.transform.position.x,
            player.transform.position.y - gun.transform.position.y);
            gun.transform.up = direction;
        }
        if(sec >= 0&&detectplayer)
        {
            lasercan = true;
        }

        if (canshoot && sec <=0)
        {
            StartCoroutine(shoot());
        }
        if (lasercan)
        {
            laser.SetPosition(0, gun.transform.position);
            laser.SetPosition(1, player.transform.position);
        }
        if (!lasercan)
        {
            laser.SetPosition(0, Vector3.zero);
            laser.SetPosition(1, Vector3.zero);
        }
        if (HP.value <= 0)
        {
            Instantiate(die, transform.position, transform.rotation);
            Destroy(fakeparent.gameObject);
        }
    }
    IEnumerator shoot()
    {
        lasercan = false;
        canshoot = false;
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        lasercan = true;
        yield return new WaitForSeconds(Random.Range(1, 5));
        canshoot = true;
        canlook = true;
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
