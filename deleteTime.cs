using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteTime : MonoBehaviour
{
    public float TimeToDel;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, TimeToDel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
