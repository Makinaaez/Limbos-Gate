using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBullet : MonoBehaviour
{
    public float timer = 0.4f;
    public float speed = 20f;
    public float damage;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
