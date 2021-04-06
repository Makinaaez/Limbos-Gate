using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer2 : MonoBehaviour
{
    public GameObject Enemie;
    public GameObject isdet;
    // Start is called before the first frame update
    private void Update()
    {
        if (isdet.GetComponent<catchplayer>().playerhere && Enemie!=null)
        {
            Enemie.gameObject.GetComponent<SniperEnemie>().detectplayer = true;
            Enemie.gameObject.GetComponent<SniperEnemie>().player = isdet.GetComponent<catchplayer>().isplay;
        }
    }
}
