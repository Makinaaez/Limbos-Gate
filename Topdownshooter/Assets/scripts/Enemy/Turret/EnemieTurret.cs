using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemieTurret : MonoBehaviour
{
    public GameObject die;
    public GameObject fakedad;
    public GameObject gun;
    public GameObject bullet;
    public bool will = false;
    public bool detectplayer=false;
    bool canlook=false;
    public bool canfollow = false;
    public bool canrotate = false;
    public GameObject player;
    public Slider HP;
    public float speed;
    public float Damagedealt;
    public float Knockbackdealt;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            canrotate = false;
            canfollow = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Bullet")
        {
            HP.value -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        if (collision.gameObject.tag == "Mele")
        {
            HP.value -= collision.gameObject.GetComponent<Melee>().damage;
            Vector2 diference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + (diference.x * collision.gameObject.GetComponent<Melee>().knockback), transform.position.y + diference.y * collision.gameObject.GetComponent<Melee>().knockback);
        }
    }
    private void Update()
    {
        if (will)
        {
            Vector2 direction = new Vector2(player.transform.position.x - gun.transform.position.x,
            player.transform.position.y - gun.transform.position.y);
            gun.transform.up = direction;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (detectplayer)
        {
            canlook = true;
            detectplayer = false;
            canfollow = true;
            will = true;
        }
        if (canlook)
        {
            StartCoroutine(shoot());
        }
        if (canfollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (canrotate)
        {
            transform.RotateAround(player.transform.position, new Vector3(0,0,1), speed*75 * Time.deltaTime);
        }
        if (HP.value <= 0)
        {
            Destroy(fakedad.gameObject);
            Instantiate(die, transform.position, transform.rotation);
        }
    }
    IEnumerator shoot()
    {
        canlook = false;
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(1);
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
}
