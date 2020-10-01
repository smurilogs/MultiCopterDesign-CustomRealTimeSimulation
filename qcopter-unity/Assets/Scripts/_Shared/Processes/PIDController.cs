using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIDController
{
    public float SP, CV, PV, lastPV, lastER, ER;
    public float KP, KI, KD, P, I, D;

    public PIDController(float aKP, float aKI, float aKD)
    {
        KP = aKP;
        KI = aKI;
        KD = aKD;

        P = 0.0f;
        I = 0.0f;
        D = 0.0f;

        lastPV = 0.0f;
        lastER = 0.0f;
        SP = 0.0f;
    }

    public float getSP()
    {
        return SP;
    }

    public void setSP(float aSP)
    {
        SP = aSP;
    }
    
    public float processCV(float aPV)
    {
        PV = aPV;
        ER = SP - PV;

        P = KP * ER;
        I = I + KI * ((ER + lastER)*(Time.fixedDeltaTime/2.0f));
        D = KD * (lastPV - PV); 

        CV = P + I + D;
        lastPV = PV;
        lastER = ER;			

        return CV;
    }

    public float getER()
    {
        return ER;
    }
}
