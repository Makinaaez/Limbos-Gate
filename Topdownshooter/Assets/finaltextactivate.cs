using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finaltextactivate : MonoBehaviour
{
    public GameObject player;
    public GameObject activate;
    public bool can = false;

    // Update is called once per frame
    void Update()
    {
        if (can)
        {
            player.SetActive(false);
            activate.SetActive(true);
        }
    }
}
