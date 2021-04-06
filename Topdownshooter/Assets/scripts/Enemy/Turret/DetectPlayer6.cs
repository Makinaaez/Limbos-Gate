using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer6 : MonoBehaviour
{
    public GameObject Enemie;
    public GameObject isdet;
    // Start is called before the first frame update
    private void Update()
    {
        if (isdet.GetComponent<catchplayer>().playerhere)
        {
            Enemie.gameObject.GetComponent<EnemieTurret>().player = isdet.GetComponent<catchplayer>().isplay;
            Enemie.gameObject.GetComponent<EnemieTurret>().detectplayer = true;
            Destroy(this.gameObject);
        }
    }
}
