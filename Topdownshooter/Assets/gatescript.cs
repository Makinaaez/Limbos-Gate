using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatescript : MonoBehaviour
{
    public GameObject dad;
    void Start()
    {
        StartCoroutine(GATETIME());
    }
    
    IEnumerator GATETIME()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        this.gameObject.GetComponent<DoDamage>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(5);
        Destroy(dad.gameObject);

    }
}
