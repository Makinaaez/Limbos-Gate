using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroy : MonoBehaviour
{
    GameObject Player;
    public int can;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("P");
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (Player == null)
        {
            Player = GameObject.Find("P");
            if (Player == null)
            {
                Destroy(this.gameObject);
            }
        }

        if (Player.GetComponent<Player>().HP.value <= 0 && Player != null)
        {
            can = 1;
            gameObject.name = "Music1";
            gameObject.GetComponent<AudioSource>().volume = 0.01f;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.08f;
        }
        if (can == 1)
        {
            GameObject copy = GameObject.Find("Music");
            if (copy != null)
            {
                Destroy(copy);
            }
        }
    }

}
