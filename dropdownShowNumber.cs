using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dropdownShowNumber : MonoBehaviour
{
    public int Numb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Numb = gameObject.GetComponent<TMP_Dropdown>().value;
    }
}
