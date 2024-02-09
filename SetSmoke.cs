using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSmoke : MonoBehaviour
{
    public GameObject smoke;


    public GameObject aimtrack;
    // Start is called before the first frame update
    void Start()
    {
        //aimtrack = GameObject.Find("findsmoke");
    }

    // Update is called once per frame
    public void SetSmokeNow()
    {
        GameObject smk = Instantiate(smoke) as GameObject;
        smk.transform.position = aimtrack . transform.position;
        smk.transform.parent = aimtrack.transform;
       
    }
}
