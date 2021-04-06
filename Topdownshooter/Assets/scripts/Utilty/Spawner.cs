using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float r;
    [Header("Options")]
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;

    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(1, 5);
        switch (r)
        {
            case 1:
                Instantiate(r1,transform.position,transform.rotation);
                break;
            case 2:
                Instantiate(r2, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(r3, transform.position, transform.rotation);
                break;
            case 4:
                Instantiate(r4, transform.position, transform.rotation);
                break;

        }
    }
}
