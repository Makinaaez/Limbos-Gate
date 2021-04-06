using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFollow : MonoBehaviour
{
    public bool canfollow = true;
    public GameObject player;
    public float follow = 3;

    // Update is called once per frame
    void Update()
    {
        follow -= Time.deltaTime;
        if (follow >= 0.1f&&canfollow)
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
            transform.up = direction;
        }
        if(follow<=0)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        this.gameObject.tag = "ASword2";
        transform.position += transform.up * Time.deltaTime * 15;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
           
    }
}
