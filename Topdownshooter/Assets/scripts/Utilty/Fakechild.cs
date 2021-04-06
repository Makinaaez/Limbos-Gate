using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fakechild : MonoBehaviour
{
    public GameObject fakechild;
    void Update()
    {
        if (fakechild != null)
        {
            this.transform.position = fakechild.transform.position;
        }
    }
}
