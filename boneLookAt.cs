using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class boneLookAt : MonoBehaviour
{
    public bool isFirstBone;
    public Vector3 FixRotation;
    public Vector3 FixTranslation;
    public GameObject AfterThisRun;
    public bool ifAfterThisRun = false;

    public Transform targetT;
    public GameObject child;
    public GameObject beCtrled;
    void LateUpdate()
    {
        //if (beCtrled)
        {
            if (beCtrled.GetComponent<ragdollCtrl>().IsRagdollActive)
            {
                gameObject.GetComponent<boneLookAt>().enabled = false;
            }
            else
            {
                BoneLook();

            }
        }
    }
    public void LookAtTarget()
    {
        if (targetT)
        {
            transform.LookAt(targetT);

        }
        transform.Rotate(FixRotation, Space.Self);
        if (child)
        {
            child.GetComponent<boneLookAt>().LookAtTarget();
        }
        if (ifAfterThisRun)
        {
            if (AfterThisRun.GetComponent<stayParentTr>())
            {
                AfterThisRun.GetComponent<stayParentTr>().SetTR();
            }

        }
    }
    public void BoneLook()
    {
        //transform.position  = transform.parent.transform.position;
        //transform.rotation = transform.parent.transform.rotation;

        if (isFirstBone == false) return;
        if (targetT)
        {
            transform.LookAt(targetT);

        }
        transform.Rotate(FixRotation, Space.Self);
        transform.Translate(FixTranslation, Space.Self);
        if (child)
        {
            child.GetComponent<boneLookAt>().LookAtTarget();

        }
        if (ifAfterThisRun)
        {
            AfterThisRun.GetComponent<stayParentTr>().SetTR();
        }
    }
}
