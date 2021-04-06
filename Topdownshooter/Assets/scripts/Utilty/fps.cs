using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour
{
    float count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       count = Time.frameCount / Time.time;
        this.GetComponent<Text>().text = count + "";
    }
}
