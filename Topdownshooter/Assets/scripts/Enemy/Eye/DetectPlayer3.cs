using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer3 : MonoBehaviour
{
    public GameObject Enemie;
    public GameObject isdet;
    // Start is called before the first frame update
    private void Update()
    {
        if (isdet.GetComponent<catchplayer>().playerhere)
        {
            Enemie.gameObject.GetComponent<EyeEnemy>().detectplayer = true;
            Enemie.gameObject.GetComponent<EyeEnemy>().player = isdet.GetComponent<catchplayer>().isplay;
        }
    }
}
