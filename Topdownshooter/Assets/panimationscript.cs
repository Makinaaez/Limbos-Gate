using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panimationscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<Animator>().SetFloat("check", 1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.GetComponent<Animator>().SetFloat("check", 2);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetFloat("check", 0);
        }
        if (Input.GetKey(KeyCode.LeftShift) && this.gameObject.GetComponent<Player>().dir && this.gameObject.GetComponent<Player>().Stamina.value >= 0)
        {
            this.gameObject.GetComponent<Animator>().SetFloat("check", 3);
        }
    }
}
