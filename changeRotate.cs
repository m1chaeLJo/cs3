using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRotate : MonoBehaviour
{
    public stayParentTr changeRotateCM;
    public Vector3 FstR;
    public Vector3 FstRw;
    public Vector3 SecR;
    public Vector3 SecRw;
    public GameObject BCTLed;
    // Start is called before the first frame update
    void Start()
    {
        changeRotateCM = gameObject.GetComponent<stayParentTr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BCTLed)
        {
            if (BCTLed.GetComponent<ragdollCtrl>().IsRagdollActive)
            {
                gameObject.GetComponent<changeRotate>().enabled = false;
            }
            else
            {

            }
        }
    }

    public void changeFtype()
    {
        changeRotateCM.TrR = FstR;
        changeRotateCM.TrRw = FstRw;
        
    }
    public void changeSType()
    {changeRotateCM.TrR = SecR;
        changeRotateCM.TrRw = SecRw;
    }
}
