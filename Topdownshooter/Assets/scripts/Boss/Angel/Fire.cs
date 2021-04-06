using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject f;
    public float autokill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        autokill -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Instantiate(f, new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z), transform.rotation);
        if (autokill <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
