using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject sword;
    public GameObject warn;
    public bool flip2 = false;
    public bool flip = false;
    public float o;
    public float direction;
    public float timer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        o = transform.rotation.z;
        timer -= Time.deltaTime;
        if (timer <= 0.5f&& timer >= 0)
        {
            warn.SetActive(false);
            sword.SetActive(true);
        }

        if (timer <= 0)
        {
            transform.RotateAround(this.transform.position, Vector3.forward, direction * Time.deltaTime);
        }

        if (o >= 0.7 && !flip && !flip2 || o <= -0.7 && !flip && !flip2)
        {
            Destroy(this.gameObject);
        }
        if (o <= 0.7 && flip && !flip2 || o >= -0.7 && flip&&o<=0 && !flip2)
        {
            Destroy(this.gameObject);
        }
        if (o <= -0.999f && !flip && flip2 )
        {
            Destroy(this.gameObject);
        }
        if (o >= 0.999f && flip && flip2)
        {
            Destroy(this.gameObject);
        }
    }
}
