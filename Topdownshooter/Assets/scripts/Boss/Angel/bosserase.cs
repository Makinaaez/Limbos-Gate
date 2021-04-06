using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosserase : MonoBehaviour
{
    public GameObject boss;
    public float threshold;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<AngelBoss>().HP.value <= threshold)
        {
            Destroy(this.gameObject);
        }
    }
}
