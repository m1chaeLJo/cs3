using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikCtrl : MonoBehaviour
{
    public Animator ani;
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAnimatorIK(int layerIndex)
    {
        ani.SetLookAtPosition(pos.transform.position);
        ani.SetLookAtWeight(1, 0.7f);
    }
}
