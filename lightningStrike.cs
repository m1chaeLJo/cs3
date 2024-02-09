using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningStrike : MonoBehaviour
{
    public bool isLightning;
    public float MaxLightingNit;
    public float StartTime;
    public float MaxTime;
    public AnimationCurve curve;

    public Material Lightning;
    public float RealtimeLit;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = 0;
    }

    void Update()
    {
        if (isLightning)
        {
            StartTime = StartTime + Time.deltaTime;
        }
        if (StartTime > MaxTime && isLightning)
        {
            isLightning = false;
        }
        if (isLightning)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                RealtimeLit = curve.Evaluate(StartTime / MaxTime);
                gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                
            }
            UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(Lightning, curve.Evaluate(StartTime / MaxTime)*MaxLightingNit);
        }
        else
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
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
