using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuS : MonoBehaviour
{
    int cannum = 0;
    public bool cando=true;
    public bool see=false;
    public GameObject player;
    public GameObject Menu;
    public GameObject UiMenu;
    public GameObject cur;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<Player>().HP.value >= 1)
        {
            switch (cannum)
            {
                case 0:
                    Menu.SetActive(true);
                    see = true;
                    cannum += 1;
                    cur.SetActive(false);
                    UiMenu.GetComponent<Image>().enabled = true ;
                    break;
                case 1:
                    Menu.SetActive(false);
                    see = false;
                    cannum -= 1;
                    cur.SetActive(true);
                    UiMenu.GetComponent<Image>().enabled = false;
                    break;
            }
        }
        else if(player.GetComponent<Player>().HP.value == 0)
        {
            Menu.SetActive(false);
            see = true;
            cur.SetActive(false);
            UiMenu.GetComponent<Image>().enabled = true;
        }

    }
}
