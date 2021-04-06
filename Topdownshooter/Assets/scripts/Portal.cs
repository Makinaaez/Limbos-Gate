using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    bool canfin=false;
    int dignum=0;
    public GameObject fate;
    public Text finalt;
    public bool final = false;
    public GameObject music;
    public bool reset=false;
    public float startscene=0;

    private void Awake()
    {
        startscene = PlayerPrefs.GetFloat("startscene");
        if (startscene == 1&&!reset)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private void Start()
    {
        if (final)
        {
            finalt.text = "You wake up in the middle of the dunes, whoever took your life didn't bother to bury you...";
        }
    }
    private void Update()
    {
        if (canfin)
        {
            fate.SetActive(true);
            if (Input.anyKeyDown)
            {
                dignum += 1;
                switch (dignum)
                {
                    case 1:
                        finalt.text = "Nevertheless, you can see a village on the horizon, with some luck, someone will know what happened";
                        break;
                    case 2:
                        finalt.text = "And so, you take your first step toward your vengeance";
                        break;
                    case 3:
                        finalt.text = "Limbo's Garden";
                        StartCoroutine(oa());
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!final)
            {
                fate.SetActive(true);
                StartCoroutine(oa());
            }
            PlayerPrefs.SetFloat("startscene", 1);
            if (final)
            {
                canfin = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!final)
            {
                fate.SetActive(true);
                StartCoroutine(oa());
            }
            PlayerPrefs.SetFloat("startscene", 1);
            if (final)
            {
                canfin = true;
            }
        }
    }
    IEnumerator oa()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(music);
        SceneManager.LoadScene("Menu");

    }
}
