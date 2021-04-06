using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float guncooldown=0.15f;
    public float checkangel;
    public GameObject death;
    Vector2 diference;
    float enemieknock;
    bool willknock=false;
    public float knocktime=0.2f;
    public Rigidbody2D me;
    public bool vampire = false;
    public float stay;
    public bool canclash = false;
    public bool seecircle = true;
    public bool canpush = true;
    public GameObject gun;
    public GameObject sword;
    public GameObject sword2;
    public Slider Stamina;
    public Slider HP;
    public Image HPc;
    private float staminaval = 100f;
    public float regenscount;
    public float regenscountrem = 5;
    public int dashcost = 25;
    Rigidbody2D body;
    private bool takestam = false;
    public bool canmove=true;
    public float dashtime;
    public float startdasht;
    public bool dir = false;
    Transform play;
    public Transform fire;
    public GameObject bullet;
    float horizontal;
    float vertical;

    public float runSpeed = 1f;
    public float dashspeed;
    public AudioSource Shoots;

    void Start()
    {
        regenscount = regenscountrem;
        sword.SetActive(false);
        play = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        dashtime = startdasht;
        stay = sword.GetComponent<Melee>().time;
        bullet.GetComponent<Bullet>().damage = 25;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<SpriteRenderer>().flipX=true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        guncooldown -= Time.deltaTime;
        checkangel = gun.transform.rotation.z;
        if (checkangel >= 0)
        {
            gun.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (checkangel <= 0)
        {
            gun.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (HP.value <= 0)
        {
            this.gameObject.SetActive(false);
            death.SetActive(true);
        }
        if (willknock)
        {
            canmove = false;
            GetComponent<Rigidbody2D>().AddForce(diference.normalized * 5, ForceMode2D.Impulse);
            knocktime -= Time.deltaTime;
            if (knocktime <= 0)
            {
                willknock = false;
                knocktime = 0.2f;
                canmove = true;
            }
        }
        if (HP.value <=HP.maxValue*0.4)
        {
            vampire = true;
            HPc.color = Color.red;
        }
        else if(HP.value >= HP.maxValue*0.4)
        {
            vampire = false;
            HPc.color = Color.green;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0)&& gun.activeInHierarchy == true&&guncooldown<=0)
        {
            Shoot();
        }
        if (dir == false&&Input.GetKeyDown(KeyCode.LeftShift) && Stamina.value>=dashcost)
        {
            this.gameObject.tag = "Untagged";
            drainstamina(dashcost);
            canmove = false;
            dir = true;
        }
        if (canmove == true)
        {
            Facemouse();
        }
        if (dashtime <= 0)
        {
            this.gameObject.tag = "Player";
            dir = false;
            canmove = true;
            dashtime = startdasht;
        }
        if (dir == true)
        {
            takestam = true;
            dashtime -= Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                body.velocity = -play.right * dashspeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                body.velocity = play.right * dashspeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                body.velocity = -play.up * dashspeed;
            }
            else
            {
                body.velocity = play.up * dashspeed;
            }
        }
        if (takestam == true)
        {
            regenscount -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(1) && stay !=0)
        {
            canclash = true;
        }
        if (canclash == true)
        {
            stay -= Time.deltaTime;
            gun.SetActive(false);
            sword.SetActive(true);
        }
        if(stay <= 0)
        {
            canclash = false;
            stay = sword.GetComponent<Melee>().time;
            gun.SetActive(true);
            sword.SetActive(false);
        }
        if(regenscount <= 0)
        {
            takestam = false;
            regenscount = regenscountrem;
        }
        if (staminaval <= Stamina.maxValue)
        {
            staminaval = Stamina.maxValue;
        }
        if (takestam == false && regenscount == regenscountrem)
        {
            Stamina.value += 0.5f;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EBullet")
        {
            HP.value -= collision.gameObject.GetComponent<EnemieBullet>().damage;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemie1")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<Enemie>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<Enemie>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                canmove = true;
            }
            if (collision.gameObject.tag == "Enemie2")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<SniperEnemie>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<SniperEnemie>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (collision.gameObject.tag == "Enemie3")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<EyeEnemy>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<EyeEnemy>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (collision.gameObject.tag == "Enemie4")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<EnemySpin>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<EnemySpin>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (collision.gameObject.tag == "Enemie5")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<EnemyGolem>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<EnemyGolem>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (collision.gameObject.tag == "Enemie6")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<EnemieTurret>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<EnemieTurret>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.GetComponent<EnemieTurret>().canfollow = false;
            }
            if (collision.gameObject.tag == "AEnemie")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<SmallA>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<SmallA>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (collision.gameObject.tag == "Denemie")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<SmallA>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<SmallA>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (collision.gameObject.tag == "Firering")
            {
                dir = false;
                dashtime = startdasht;
                HP.value -= collision.gameObject.GetComponent<DoDamage>().Damagedealt;
                knocktime = collision.gameObject.GetComponent<DoDamage>().Knockbackdealt;
                diference = transform.position - collision.transform.position;
                willknock = true;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (canmove == true)
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
    void Shoot()
    {
        Shoots.Play();
        Instantiate(bullet,  fire.position, fire.rotation);
        guncooldown = 0.15f;
    }
    void Facemouse()
    {
        Vector3 mouseP = Input.mousePosition;
        mouseP = Camera.main.ScreenToWorldPoint(mouseP);

        Vector2 direction = new Vector2(mouseP.x-transform.position.x,
            mouseP.y-transform.position.y);
        gun.transform.up = direction;
        sword2.transform.up = direction;
    }
    void drainstamina(int take)
    {
        Stamina.value -= take;
    }
    void Clash()
    {
    }
}
