using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class tutorialinput : MonoBehaviour
{
    public CinemachineVirtualCamera camerra;
    public GameObject door;
    public GameObject player;
    public GameObject chat;
    public GameObject button;
    public Text chat2;
    public string texto;
    public string texto2;
    public float number;
    void Update()
    {
        switch (number)
        {
            case 1:
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    chat.SetActive(false);
                    number = 0;
                    Destroy(this.gameObject);
                }
                break;
            case 2:
                if (Input.GetMouseButtonDown(0))
                {
                    chat.SetActive(false);
                    number = 0;
                    Destroy(this.gameObject);
                }
                break;
            case 3:
                if (Input.GetMouseButtonDown(1))
                {
                    chat.SetActive(false);
                    number = 0;
                    Destroy(this.gameObject);
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    chat.SetActive(false);
                    number = 0;
                    Destroy(this.gameObject);
                }
                break;
            case 5:
                camerra.Follow = door.transform;
                camerra.LookAt = door.transform;
                player.SetActive(false);
                if (Input.anyKeyDown)
                {
                    chat.SetActive(false);
                    button.SetActive(true);
                }
                break;
            case 6:
                chat2.text = texto2;
                chat.SetActive(true);
                button.SetActive(false);
                if (Input.anyKeyDown)
                {
                    chat.SetActive(false);
                    player.SetActive(true);
                    camerra.Follow = player.transform;
                    camerra.LookAt = player.transform;
                    Destroy(this.gameObject);
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&this.gameObject.tag == "first")
        {
            number = 1;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "second")
        {
            number = 2;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "third")
        {
            number = 3;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "fourth")
        {
            number = 4;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "cinco")
        {
            number = 5;
            chat2.text = texto;
            chat.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "first")
        {
            number = 1;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "second")
        {
            number = 2;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "third")
        {
            number = 3;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "fourth")
        {
            number = 4;
            chat2.text = texto;
            chat.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "cinco")
        {
            number = 5;
            chat2.text = texto;
            chat.SetActive(true);
        }
    }
    public void ola()
    {
        number = 6;
    }

}
