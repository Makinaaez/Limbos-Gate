using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detp : MonoBehaviour
{
    public GameObject Enemie;
    public GameObject isdet;
    // Start is called before the first frame update
    private void Update()
    {
        if (isdet.GetComponent<catchplayer>().playerhere)
        {
            Enemie.gameObject.GetComponent<turretcristalenemie>().detectplayer = true;
            Enemie.gameObject.GetComponent<turretcristalenemie>().player = isdet.GetComponent<catchplayer>().isplay;
        }
    }
}
