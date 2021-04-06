using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSound : MonoBehaviour
{
    public Player p;
    public float lasthp;
    public AudioSource walk;
    public AudioSource Dash;
    public AudioSource hit;
    public AudioSource Attk;
    public AudioSource Die;
    private void Start()
    {
        p = GameObject.Find("P").GetComponent<Player>();
        lasthp = p.HP.value;
    }
    void Update()
    {
        if (lasthp != p.HP.value)
        {
            if(p.HP.value > 0)
            {
                hit.Play();
            }
            else
            {
                Die.Play();
            }
            lasthp = p.HP.value;
        }
        if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal"))
        {
            if(p.enabled == true)
            {
                walk.Play();
            }
        }
        if (Input.GetMouseButtonDown(1) && p.canclash && p.enabled == true)
        {
            Attk.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && p.Stamina.value >= p.dashcost)
        {
            Dash.Play();
        }
        if(Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
        {
            walk.Stop();
        }
        
    }
}
