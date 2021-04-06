using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretcristalenemie : MonoBehaviour
{
    public GameObject charge;
    public GameObject die;
    float sec=2;
    public bool detectplayer = false;
    public GameObject fakeparent;
    public GameObject gun;
    public GameObject bullet;
    public bool canshoot = true;
    public bool canlook = false;
    public GameObject player;
    public Slider HP;
    public float Damagedealt;
    public float Knockbackdealt;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            HP.value -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        if (collision.gameObject.tag == "Mele")
        {
            HP.value -= collision.gameObject.GetComponent<Melee>().damage;
            Vector2 diference = transform.position - collision.transform.position;
        }
    }
    private void Update()
    {
        if (detectplayer)
        {
            sec -= Time.deltaTime;
            canlook = true;
        }
        if (canlook)
        {
            Vector2 direction = new Vector2(player.transform.position.x - gun.transform.position.x,
            player.transform.position.y - gun.transform.position.y);
            gun.transform.up = direction;
        }

        if (canshoot && sec <= 0)
        {
            StartCoroutine(shoot());
        }
        if (HP.value <= 0)
        {
            Instantiate(die, transform.position, transform.rotation);
            Destroy(fakeparent.gameObject);
        }
    }
    IEnumerator shoot()
    {
        canshoot = false;
        charge.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        charge.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        canshoot = true;
        canlook = true;
    }
}
