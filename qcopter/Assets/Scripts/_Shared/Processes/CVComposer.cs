using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVComposer
{
    public float CVOffset = 0.0f;
    public float K1, K2, K3, K4;
    public float ER1, ER2, ER3, ER4;
    public float CV1, CV2, CV3, CV4;

    public CVComposer(float aK1, float aK2, float aK3, float aK4)
    {
        K1 = aK1;
        K2 = aK2;
        K3 = aK3;
        K4 = aK4;
    }

    public void setCVOffset(float aCVOffset)
    {
        CVOffset = aCVOffset;
    }

    public void setERs(float aER1, float aER2, float aER3, float aER4)
    {
        ER1 = aER1;
        ER2 = aER2;
        ER3 = aER3;
        ER4 = aER4;        
    }

    public void setCVs(float aCV1, float aCV2, float aCV3, float aCV4)
    {
        CV1 = aCV1;
        CV2 = aCV2;
        CV3 = aCV3;
        CV4 = aCV4; 
    }
    
    public float processResultCV()
    {
        float W1 = ER1 * K1;
        float W2 = ER2 * K2;
        float W3 = ER3 * K3;
        float W4 = ER4 * K4;

        float resultCV = CVOffset + (W1*CV1 + W2*CV2 + W3*CV3 + W4*CV4)/(W1 + W2 + W3 + W4);

        return resultCV;           
    }
}
