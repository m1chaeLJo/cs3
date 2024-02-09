using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDel : MonoBehaviour
{
    public float dleT;
    public float Timee;
    // Start is called before the first frame update
    void Start()
    {
        Timee = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timee = Timee + Time.deltaTime;
        if (Timee > dleT)
        {
            Destroy(gameObject);
        }
    }
}
