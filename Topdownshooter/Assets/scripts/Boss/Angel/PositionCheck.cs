using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public TriggerCheck R;
    public TriggerCheck UR;
    public TriggerCheck UL;
    public TriggerCheck L;
    public TriggerCheck DR;
    public TriggerCheck DL;
    public TriggerCheck U;
    public TriggerCheck D;
    public float Pos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (R.Is)
        {
            Pos = 1;
            UR.Is = false;
            UL.Is = false;
            U.Is = false;
            D.Is = false;
            DR.Is = false;
            DL.Is = false;
            L.Is = false;
        }
        else if(UR.Is)
        {
            Pos = 2;
            R.Is = false;
            UL.Is = false;
            U.Is = false;
            D.Is = false;
            DR.Is = false;
            DL.Is = false;
            L.Is = false;
        }
        else if(UL.Is)
        {
            Pos = 3;
            R.Is = false;
            UR.Is = false;
            U.Is = false;
            D.Is = false;
            DR.Is = false;
            DL.Is = false;
            L.Is = false;
        }
        else if(U.Is)
        {
            Pos = 4;
            R.Is = false;
            UL.Is = false;
            UR.Is = false;
            D.Is = false;
            DR.Is = false;
            DL.Is = false;
            L.Is = false;
        }
        else if(D.Is)
        {
            Pos = 5;
            R.Is = false;
            UL.Is = false;
            U.Is = false;
            UR.Is = false;
            DR.Is = false;
            DL.Is = false;
            L.Is = false;
        }
        else if(DR.Is)
        {
            Pos = 6;
            R.Is = false;
            UL.Is = false;
            U.Is = false;
            UR.Is = false;
            D.Is = false;
            DL.Is = false;
            L.Is = false;
        }
        else if(DL.Is)
        {
            Pos = 7;
            R.Is = false;
            UL.Is = false;
            U.Is = false;
            UR.Is = false;
            DR.Is = false;
            D.Is = false;
            L.Is = false;
        }
        else if (L.Is)
        {
            Pos = 8;
            R.Is = false;
            UL.Is = false;
            U.Is = false;
            UR.Is = false;
            DR.Is = false;
            DL.Is = false;
            D.Is = false;
        }
        else
        {
            Pos = 0;
        }
    }
}
