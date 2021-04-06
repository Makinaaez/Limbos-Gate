using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public bool a=false;
    public bool b=false;
    public bool c=false;
    bool set1=false;
    public int dignum = 0;
    bool set2=false;
    public GameObject diag;
    public Text diagtext;
    public GameObject close;
    public CinemachineVirtualCamera camerra;
    public GameObject player;
    public GameObject boss;
    public GameObject canvas;
    bool e =true;
    public float bosc;
    
    private void Start()
    {
        bosc = PlayerPrefs.GetFloat("bosschat");
        if (bosc == 0)
        {
            diagtext.text = "Oh, it was you who caused the comotion...";
        }
        else
        {
            bosc = Random.Range(1, 4);
            switch (bosc)
            {
                case 1:
                    diagtext.text = "Mmm, how strange";
                    break;
                case 2:
                    diagtext.text = "Your posetions, the items that you brought to this place...";
                    break;
                case 3:
                    diagtext.text = "Once again you come, standing between life and death";
                    break;
            }
        }
    }
    private void Update()
    {
        if (set1)
        {
            diag.gameObject.SetActive(true);
            diagtext.gameObject.SetActive(true);
            if (Input.anyKeyDown)
            {
                if (bosc == 0)
                {
                    dignum += 1;
                    switch (dignum)
                    {
                        case 1:
                            PlayerPrefs.SetFloat("bosschat", 5);
                            diagtext.text = "I'm afraid this is where your journey ends";
                            break;
                        case 2:
                            diagtext.text = "Rest in peace, oh doomed soul";
                            break;
                        case 3:
                            diag.gameObject.SetActive(false);
                            diagtext.gameObject.SetActive(false);
                            player.SetActive(true);
                            camerra.Follow = player.transform;
                            camerra.LookAt = player.transform;
                            if (a)
                            {
                                close.SetActive(true);
                                boss.GetComponent<AngelBoss>().PlayerH = player;
                                boss.GetComponent<AngelBoss>().start = true;
                            }
                            Destroy(this.gameObject);
                            break;
                    }
                }
                else
                {
                    switch (bosc)
                    {
                        case 1:
                            dignum += 1;
                            switch (dignum)
                            {
                                case 1:
                                    diagtext.text = "The soul crystal have yet to consume you";
                                    break;
                                case 2:
                                    diagtext.text = "how come your will be so strong?";
                                    break;
                                case 3:
                                    PlayerPrefs.SetFloat("bosschat", 5);
                                    diag.gameObject.SetActive(false);
                                    diagtext.gameObject.SetActive(false);
                                    player.SetActive(true);
                                    camerra.Follow = player.transform;
                                    camerra.LookAt = player.transform;
                                    if (a)
                                    {
                                        close.SetActive(true);
                                        boss.GetComponent<AngelBoss>().PlayerH = player;
                                        boss.GetComponent<AngelBoss>().start = true;
                                    }
                                    Destroy(this.gameObject);
                                    break;
                            }
                            break;
                        case 2:
                            dignum += 1;
                            switch (dignum)
                            {
                                case 1:
                                    diagtext.text = "you died with a thirst for blood";
                                    break;
                                case 2:
                                    diagtext.text = "another reason to never let you pass";
                                    break;
                                case 3:
                                    PlayerPrefs.SetFloat("bosschat", 5);
                                    diag.gameObject.SetActive(false);
                                    diagtext.gameObject.SetActive(false);
                                    player.SetActive(true);
                                    camerra.Follow = player.transform;
                                    camerra.LookAt = player.transform;
                                    if (a)
                                    {
                                        close.SetActive(true);
                                        boss.GetComponent<AngelBoss>().PlayerH = player;
                                        boss.GetComponent<AngelBoss>().start = true;
                                    }
                                    Destroy(this.gameObject);
                                    break;
                            }
                            break;
                        case 3:
                            dignum += 1;
                            switch (dignum)
                            {
                                case 1:
                                    diagtext.text = "yet you do not belong amongst the living";
                                    break;
                                case 2:
                                    diagtext.text = "your judgment day is ever so closer, and my word is not on your favor.";
                                    break;
                                case 3:
                                    PlayerPrefs.SetFloat("bosschat", 5);
                                    diag.gameObject.SetActive(false);
                                    diagtext.gameObject.SetActive(false);
                                    player.SetActive(true);
                                    camerra.Follow = player.transform;
                                    camerra.LookAt = player.transform;
                                    if (a)
                                    {
                                        close.SetActive(true);
                                        boss.GetComponent<AngelBoss>().PlayerH = player;
                                        boss.GetComponent<AngelBoss>().start = true;
                                    }
                                    Destroy(this.gameObject);
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&e)
        {
            player = collision.gameObject;
            camerra.m_Lens.OrthographicSize = 6.5f;
            camerra.Follow = boss.transform;
            camerra.LookAt = boss.transform;
            StartCoroutine(move());
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && e)
        {
            player = collision.gameObject;
            camerra.m_Lens.OrthographicSize = 6.5f;
            camerra.Follow = boss.transform;
            camerra.LookAt = boss.transform;
            StartCoroutine(move());
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
    IEnumerator move()
    {
        canvas.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(3);
        set1 = true;
    }
}
