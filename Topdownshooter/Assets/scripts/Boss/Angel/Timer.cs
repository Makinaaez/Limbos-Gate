using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject spot;
    public GameObject swords;
    void Start()
    {
        StartCoroutine(Switcht());
    }

    IEnumerator Switcht()
    {
        yield return new WaitForSeconds(1);
        spot.SetActive(false);
        swords.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);

    }

}
