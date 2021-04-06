using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer1 : MonoBehaviour
{
    public GameObject spot;
    public GameObject swords;
    void Start()
    {
        StartCoroutine(Switcht());
    }

    IEnumerator Switcht()
    {
        yield return new WaitForSeconds(2.5f);
        spot.SetActive(false);
        swords.SetActive(true);
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }

}
