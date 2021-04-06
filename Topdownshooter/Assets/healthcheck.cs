using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcheck : MonoBehaviour
{
    public bool can = true;
    public GameObject boss;
    public Sprite other;

    void Update()
    {
        if(boss.GetComponent<AngelBoss>().HP.value <= 2500&&can)
        {
            can = false;
            StartCoroutine(transf());
        }
        if (boss.GetComponent<AngelBoss>().HP.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator transf()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = other;
    }
}
