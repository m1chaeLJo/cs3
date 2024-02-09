using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayParentTr : MonoBehaviour
{
    public GameObject ForceParent;
    public Vector3 Tr;
    public Vector3 TrR;
    public Vector3 Trw;
    public Vector3 TrRw;
    public bool isRotate = true;
    public bool isTranslate = true;
    public bool ifOverT = true;
    public bool ifOverR = true;

    public GameObject AfterRun;
    public GameObject BeCtrled;
    // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        //if (BeCtrled)
        {
            if (BeCtrled.GetComponent<ragdollCtrl>().IsRagdollActive)
            {
                gameObject.GetComponent<stayParentTr>().enabled = false;
            }
            else
            {
                SetTR();

            }
        }
        
    }
    public void SetTR()
    {
        if (isTranslate)
        {
            if (ifOverT)
            {
                if (ForceParent)
                {
                    transform.position = ForceParent.transform.position;

                }
                else
                {
                    if (transform.parent)
                    {
                        transform.position = transform.parent.transform.position;

                    }

                }

            }
            transform.Translate(Tr, Space.Self);
            transform.Translate(Trw, Space.World);
        }
        if (isRotate)
        {
            if (ifOverR)
            {
                if (ForceParent)
                {
                    transform.rotation = ForceParent.transform.rotation;

                }
                else
                {
                    if (transform.parent){
                    transform.rotation = transform.parent.transform.rotation;

                    }

                }

            }
            transform.Rotate(TrR, Space.Self);
            transform.Rotate(TrRw, Space.World);


        }
        if (AfterRun)
        {
            AfterRun.GetComponent<boneLookAt>().BoneLook();
        }
    }
}
