using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recize : MonoBehaviour
{
    void Update()
    {
        transform.localScale *= 1+Time.deltaTime * 1.5f;
    }
}
