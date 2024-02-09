using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFstSec : MonoBehaviour
{
    public GameObject Fst;
    public GameObject Sec;
    // Start is called before the first frame update
    void Start()
    {
        Fst.GetComponent<stayParentTr>().enabled = false;
        //Sec .GetComponent<stayParentTr>().enabled = false;
        
        //Sec .GetComponent<stayParentTr>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fst.GetComponent<stayParentTr>().enabled = true;
    }
}
