using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorThings : MonoBehaviour
{
    public List<GameObject> GobjL;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GobjL.Count; i++)

        {
            if (GobjL[i].GetComponent<MeshCollider>())
            {
                GobjL[i].GetComponent<MeshCollider>().enabled = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
