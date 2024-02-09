using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorDelCollider : MonoBehaviour
{
    public GameObject mapDTCThings;
    public List<GameObject> GobjL;
    // Start is called before the first frame update
    void Start()
    {
        mapDTCThings = GameObject.FindGameObjectWithTag("map");
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            collision.gameObject.GetComponent<MeshCollider>().enabled = false;
            mapDTCThings.GetComponent<detectorThings>().GobjL.Add(collision.gameObject);
            
        }
        
    }
    
    
}
