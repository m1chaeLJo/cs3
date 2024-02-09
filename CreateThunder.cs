using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateThunder : MonoBehaviour
{
    public GameObject AIM1;
    public GameObject AIM2;
    public GameObject AIM3; 
    public GameObject AIM4;
    public GameObject AIM5;
    public GameObject AIM6;
    public GameObject AIM7;
    public GameObject Thunder;

    public List<GameObject> creatPoint;
    public int readCREATPOINT;


    public float AwakeTime = 0f;
    public Material TD;
    public int DecreaseSpeed;
    public int StartNum;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if ((StartNum - AwakeTime * DecreaseSpeed) > 0)
        {

            UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(TD, StartNum - AwakeTime * DecreaseSpeed);
        }
        else
        {
            UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(TD, 0);

        }
        AwakeTime = AwakeTime + Time.deltaTime;

    }
    public void CreateT()
    {
        readCREATPOINT = 1;
        while (readCREATPOINT <= creatPoint.Count)
        {
            //Instantiate(Thunder,creatPoint[readCREATPOINT].transform, creatPoint[readCREATPOINT ].transform);

            readCREATPOINT++;
        }
        GameObject thunder = Instantiate(Thunder) as GameObject;
        thunder.transform.position = AIM1.transform.position;
        thunder.transform.parent = AIM1.transform;

        GameObject thunder1 = Instantiate(Thunder) as GameObject;
        thunder1.transform.position = AIM2.transform.position;
        thunder1.transform.parent = AIM2.transform;

        GameObject thunder2 = Instantiate(Thunder) as GameObject;
        thunder2.transform.position = AIM3.transform.position;
        thunder2.transform.parent = AIM3.transform;

        GameObject thunder3 = Instantiate(Thunder) as GameObject;
        thunder3.transform.position = AIM4.transform.position;
        thunder3.transform.parent = AIM4.transform; 
        
        GameObject thunder4 = Instantiate(Thunder) as GameObject;
        thunder4.transform.position = AIM5.transform.position;
        thunder4.transform.parent = AIM5.transform;

        GameObject thunder5 = Instantiate(Thunder) as GameObject;
        thunder5.transform.position = AIM6.transform.position;
        thunder5.transform.parent = AIM6.transform;

        GameObject thunder6 = Instantiate(Thunder) as GameObject;
        thunder6.transform.position = AIM7.transform.position;
        thunder6.transform.parent = AIM7.transform;
    }
    public void UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(Material material, float intensity)
    {
        const string kEmissiveColorLDR = "_EmissiveColorLDR";
        const string kEmissiveColor = "_EmissiveColor";
        const string kEmissiveIntensity = "_EmissiveIntensity";

        if (material.HasProperty(kEmissiveColorLDR) && material.HasProperty(kEmissiveIntensity) && material.HasProperty(kEmissiveColor))
        {
            // Important: The color picker for kEmissiveColorLDR is LDR and in sRGB color space but Unity don't perform any color space conversion in the color
            // picker BUT only when sending the color data to the shader... So as we are doing our own calculation here in C#, we must do the conversion ourselves.
            Color emissiveColorLDR = material.GetColor(kEmissiveColorLDR);
            Color emissiveColorLDRLinear = new Color(Mathf.GammaToLinearSpace(emissiveColorLDR.r), Mathf.GammaToLinearSpace(emissiveColorLDR.g), Mathf.GammaToLinearSpace(emissiveColorLDR.b));
            material.SetColor(kEmissiveColor, emissiveColorLDRLinear * intensity);
        }
    }
}
