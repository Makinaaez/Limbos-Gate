using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelBoss : MonoBehaviour
{
    bool carcelsi = true;
    GameObject c1;
    GameObject c2;
    bool inmor = false;
    bool cantran = true;
    bool cantran2 = true;
    bool cancancel=true;
    float fakecooldown;
    float cancelattack;
    bool cancelattack2 = false;
    public bool start = false;
    [Header("1's Attack")]
    public GameObject SwordCorner;
    public GameObject corner1;
    public GameObject corner2;
    public GameObject corner3;
    public GameObject corner4;
    [Header("2's Attack")]
    public GameObject UnlimitadeBL;
    [Header("3's Attack")]
    public GameObject LAngel;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    public GameObject Spawn6;
    float secondwave = 3;
    [Header("4's Attack")]
    public GameObject Sword;
    [Header("5's Attack")]
    public GameObject Laser;
    [Header("6's Attack")]
    public GameObject firefollow;
    [Header("7's Attack")]
    float scythenumb;
    public GameObject scytheloc1;
    public GameObject scytheloc2;
    public GameObject scytheloc3;
    public GameObject scytheloc4;
    public GameObject scythewep;
    [Header("8's Attack")]
    public GameObject Minidemon;
    [Header("9's Attack")]
    public GameObject Summona;
    [Header("10's Attack")]
    public GameObject Meleatc;
    [Header ("Handler")]
    public PositionCheck poscheck;
    public GameObject PlayerH;
    public float attackchance = 0;
    public float cooldown1=3;
    public bool secondphase = false;
    public GameObject transition;
    public GameObject transition2;
    [Header("Self")]
    public Sprite demon;
    public Slider HP;
    public AudioSource sound1;
    public AudioSource sound2;
    // Start is called before the first frame update
    void Start()
    {
        attackchance = Random.Range(1, 6); 
    }


    void Update()
    {
        if (!carcelsi)
        {
            StartCoroutine(HOLDCARCERL());
        }
        if (cancelattack2)
        {
            cancelattack -= Time.deltaTime;
        }
        switch (fakecooldown)
        {
            case 1:
                attackchance = Random.Range(1, 6);
                if (attackchance != 1)
                {
                    fakecooldown = 0;
                }
                break;
            case 2:
                attackchance = Random.Range(1, 6);
                if (attackchance != 2)
                {
                    fakecooldown = 0;
                }
                break;
            case 3:
                attackchance = Random.Range(1, 6);
                if (attackchance != 3)
                {
                    fakecooldown = 0;
                }
                break;
            case 4:
                attackchance = Random.Range(1, 6);
                if (attackchance != 4)
                {
                    fakecooldown = 0;
                }
                break;
            case 5:
                attackchance = Random.Range(1, 6);
                if (attackchance != 5)
                {
                    fakecooldown = 0;
                }
                break;
            case 6:
                attackchance = Random.Range(6, 11);
                if (attackchance != 6)
                {
                    fakecooldown = 0;
                }
                break;
            case 7:
                attackchance = Random.Range(6, 11);
                if (attackchance != 7)
                {
                    fakecooldown = 0;
                }
                break;
            case 8:
                attackchance = Random.Range(6, 11);
                if (attackchance != 8)
                {
                    fakecooldown = 0;
                }
                break;
            case 9:
                attackchance = Random.Range(6, 11);
                if (attackchance != 9)
                {
                    fakecooldown = 0;
                }
                break;
            case 10:
                attackchance =Random.Range(6, 11);
                if (attackchance != 10)
                {
                    fakecooldown = 0;
                }
                break;
        }
        if (start)
        {
            cooldown1 -= Time.deltaTime;
        }
        if (cooldown1 <= 0&&!secondphase&&fakecooldown==0)
        {
            switch (attackchance)
            {
                case 1:
                    if (cancancel && poscheck.Pos == 0)
                    {
                        cancelattack = 0.5f;
                        cancancel = false;
                        cancelattack2 = true;
                    }
                    if (cancelattack <= 0)
                    {
                        cancelattack2 = false;
                        cancancel = true;
                        attackchance = 0;
                        cooldown1 = 0.1f;
                        fakecooldown = 1;
                    }
                    switch (poscheck.Pos)
                    {
                        case 2:
                            SwordCorner.GetComponent<RotateObject>().flip = false;
                            SwordCorner.GetComponent<RotateObject>().direction = -200;
                            Instantiate(SwordCorner, corner4.transform.position, corner4.transform.rotation);
                            attackchance = 0;
                            cooldown1 = 1;
                            fakecooldown = 1;
                            break;
                        case 3:
                            SwordCorner.GetComponent<RotateObject>().flip = false;
                            SwordCorner.GetComponent<RotateObject>().direction = 200;
                            Instantiate(SwordCorner, corner3.transform.position, corner3.transform.rotation);
                            attackchance = 0;
                            cooldown1 = 1;
                            fakecooldown = 1;
                            break;
                        case 7:
                            SwordCorner.GetComponent<RotateObject>().flip = true;
                            SwordCorner.GetComponent<RotateObject>().direction = -200;
                            Instantiate(SwordCorner, corner2.transform.position, corner2.transform.rotation);
                            attackchance = 0;
                            cooldown1 = 1;
                            fakecooldown = 1;
                            break;
                        case 6:
                            SwordCorner.GetComponent<RotateObject>().flip = true;
                            SwordCorner.GetComponent<RotateObject>().direction = 200;
                            Instantiate(SwordCorner,corner1.transform.position, corner1.transform.rotation);
                            attackchance = 0;
                            cooldown1 = 1;
                            fakecooldown = 1;
                            break;
                    }
                    break;
                case 2:
                    Instantiate(UnlimitadeBL, PlayerH.transform.position, UnlimitadeBL.transform.rotation);
                    attackchance = 0;
                    cooldown1 = 1;
                    fakecooldown = 2;
                    break;
                case 3:
                    LAngel.GetComponent<SmallA>().player = PlayerH;
                    Instantiate(LAngel, Spawn1.transform.position, LAngel.transform.rotation);
                    Instantiate(LAngel, Spawn2.transform.position, LAngel.transform.rotation);
                    Instantiate(LAngel, Spawn3.transform.position, LAngel.transform.rotation);
                    attackchance = 12;
                    break;
                case 12:
                    secondwave -= Time.deltaTime;
                    if (secondwave <= 0)
                    {
                        Instantiate(LAngel, Spawn4.transform.position, LAngel.transform.rotation);
                        Instantiate(LAngel, Spawn5.transform.position, LAngel.transform.rotation);
                        Instantiate(LAngel, Spawn6.transform.position, LAngel.transform.rotation);
                        attackchance = 0;
                        cooldown1 = 1.5f;
                        secondwave = 3;
                        fakecooldown = 3;
                    }
                    break;
                case 4:
                    Sword.GetComponent<SwordFollow>().player = PlayerH;
                    Instantiate(Sword, new Vector3(transform.position.x+0.5f,transform.position.y, transform.position.z), transform.rotation);
                    attackchance = 0;
                    cooldown1 = 0.5f;
                    fakecooldown = 4;
                    break;
                case 5:
                    if (cancancel&& poscheck.Pos == 0)
                    {
                        cancancel = false;
                        cancelattack2 = true;
                        cancelattack =0.5f;
                    }
                    if (cancelattack <= 0)
                    {
                        cancelattack2 = false;
                        cancancel = true;
                        attackchance = 0;
                        cooldown1 = 0.1f;
                        fakecooldown = 5;
                    }
                    if (poscheck.Pos==6|| poscheck.Pos == 7||poscheck.Pos == 5)
                    {
                        Laser.GetComponent<RotateObject>().flip = false;
                        Laser.GetComponent<RotateObject>().direction = -400;
                        Instantiate(Laser, transform.position, transform.rotation);
                        attackchance = 0;
                        cooldown1 = 1;
                        fakecooldown = 5;
                    }
                    if (poscheck.Pos == 2 || poscheck.Pos == 3 || poscheck.Pos == 4)
                    {
                        Laser.GetComponent<RotateObject>().flip = true;
                        Laser.GetComponent<RotateObject>().direction = 400;
                        Instantiate(Laser, transform.position, transform.rotation);
                        attackchance = 0;
                        cooldown1 = 1;
                        fakecooldown = 5;
                    }
                    break;
            }
        }
        if (HP.value <= 2500)
        {
            if (cantran)
            {
                attackchance = 50;
                c1 = GameObject.FindGameObjectWithTag("Canvas1");
                c2 = GameObject.FindGameObjectWithTag("Canvas2");
                c1.SetActive(false);
                c2.SetActive(false);
                inmor = true;
                if (inmor)
                {
                    HP.value = 2500;
                }
                sound1.Play();
                cantran = false;
                Instantiate(transition, transform.position, transform.rotation);
                StartCoroutine(MiniA());
            }
        }
        if (HP.value <= 0)
        {
            if (cantran2)
            {
                attackchance = 50;
                cantran2 = false;
                c1.SetActive(false);
                c2.SetActive(false);
                sound2.Play();
                Instantiate(transition2, transform.position, transform.rotation);
                StartCoroutine(MiniA2());
            }
        }
        if (secondphase && cooldown1 <= 0 && fakecooldown == 0)
        {
             switch (attackchance)
            {
                case 6:
                    attackchance = 0;
                    cooldown1 = 1.5f;
                    fakecooldown = 6;
                    firefollow.GetComponent<Fire>().autokill = 6;
                    firefollow.GetComponent<Fire>().player = PlayerH;
                    Instantiate(firefollow, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    break;
                case 7:
                    scythenumb = Random.Range(1, 3);
                    switch (scythenumb)
                    {
                        case 1:
                            scythenumb = 0;
                            Instantiate(scythewep, scytheloc1.transform.position, scytheloc1.transform.rotation);
                            Instantiate(scythewep, scytheloc2.transform.position, scytheloc2.transform.rotation);
                            attackchance = 0;
                            cooldown1 = 0.5f;
                            fakecooldown = 7;
                            break;
                        case 2:
                            scythenumb = 0;
                            Instantiate(scythewep, scytheloc3.transform.position, scytheloc3.transform.rotation);
                            Instantiate(scythewep, scytheloc4.transform.position, scytheloc4.transform.rotation);
                            attackchance = 0;
                            cooldown1 = 0.8f;
                            fakecooldown = 7;
                            break;
                    }
                    break;
                case 8:
                    Minidemon.GetComponent<SmallA>().player = PlayerH;
                    Instantiate(Minidemon, Spawn1.transform.position, LAngel.transform.rotation);
                    Instantiate(Minidemon, Spawn2.transform.position, LAngel.transform.rotation);
                    Instantiate(Minidemon, Spawn3.transform.position, LAngel.transform.rotation);
                    attackchance = 62;
                    break;
                case 62:
                    secondwave -= Time.deltaTime;
                    if (secondwave <= 0)
                    {
                        Instantiate(Minidemon, Spawn4.transform.position, LAngel.transform.rotation);
                        Instantiate(Minidemon, Spawn5.transform.position, LAngel.transform.rotation);
                        Instantiate(Minidemon, Spawn6.transform.position, LAngel.transform.rotation);
                        attackchance = 0;
                        cooldown1 = 1.5f;
                        secondwave = 3;
                        fakecooldown = 8;
                    }
                    break;
                case 9:
                    Instantiate(Summona, PlayerH.transform.position, UnlimitadeBL.transform.rotation);
                    attackchance = 0;
                    cooldown1 = 1.5f;
                    fakecooldown = 9;
                    break;
                case 10:
                    if (carcelsi)
                    {

                        Instantiate(Meleatc, new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), transform.rotation);
                        attackchance = 0;
                        carcelsi = false;
                        cooldown1 = 1;
                        fakecooldown = 10;
                    }
                    else
                    {
                        attackchance = 0;
                        cooldown1 = 0;
                        fakecooldown = 10;
                    }
                    break;
            }

            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            HP.value -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        if (collision.gameObject.tag == "Mele")
        {
            HP.value -= collision.gameObject.GetComponent<Melee>().damage;
        }
    }
    IEnumerator MiniA()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.11f, -0.43f);
        this.gameObject.GetComponent<Animator>().SetBool("Candemon", true);
        yield return new WaitForSeconds(0.5f);
        attackchance = Random.Range(6, 11);
        cooldown1 = 1.5f;
        c1.SetActive(true);
        c2.SetActive(true);
        secondphase = true;
        inmor = false;

    }
    IEnumerator MiniA2()
    {
        yield return new WaitForSeconds(2.4f);
        c1.SetActive(true);
        Destroy(this.gameObject);

    }
    IEnumerator HOLDCARCERL()
    {
        yield return new WaitForSeconds(8.3f);
        carcelsi = true;
    }
}
