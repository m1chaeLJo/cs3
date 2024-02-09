using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetViewOrNot : MonoBehaviour
{
    public PhotonView PTV;
    public GameObject BodY1;
    public GameObject BodY2;
    public GameObject BodY3;
    public GameObject BodY4;
    public GameObject BodY5;
    public bool AllView; public bool menuPlayer;



    public GameObject FstView;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("menuMAIN")) {
            if (GameObject.Find("menuMAIN").GetComponent<menu>().MainMenu || GameObject.Find("mainStopMenu"))
        {
            menuPlayer = true;
            //Cursor.lockState = CursorLockMode.None;
            //this.GetComponent<CPMPlayer>().enabled = false;
        }
}
            
        //PTV = GameObject.Find("menu").GetComponent<PhotonView>();
        if (PTV == false || PTV.IsMine)
        {
            FstView.SetActive(true);
            //FstView.GetComponent<Renderer>().enabled = true;
            BodY1.GetComponent<SkinnedMeshRenderer>().enabled = false;
            BodY3.GetComponent<SkinnedMeshRenderer>().enabled = false;
            BodY4.GetComponent<SkinnedMeshRenderer>().enabled = false;
            BodY2.GetComponent<SkinnedMeshRenderer>().enabled = false;
            BodY5.GetComponent<SkinnedMeshRenderer>().enabled = false;
            gameObject.tag = "Player";
        }
        else
        {
            FstView.SetActive(false);

            //FstView.GetComponent<Renderer>().enabled = false;
            BodY1.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY2.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY3.GetComponent<SkinnedMeshRenderer>().enabled = true; 
            BodY4.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY5.GetComponent<SkinnedMeshRenderer>().enabled = true;

            gameObject.tag = "otherPlayer";


        }
        if (menuPlayer)
        {
            FstView.SetActive(false);

            //FstView.GetComponent<Renderer>().enabled = false;
            BodY1.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY2.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY3.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY4.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY5.GetComponent<SkinnedMeshRenderer>().enabled = true;

            gameObject.tag = "otherPlayer";

        }
        if (AllView)
        {
            FstView.SetActive(true);
            BodY1.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY2.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY3.GetComponent<SkinnedMeshRenderer>().enabled = true;
            BodY4.GetComponent<SkinnedMeshRenderer>().enabled = true; 
            BodY5.GetComponent<SkinnedMeshRenderer>().enabled = true;

        }
    }
    public void aLLview()
    {
        FstView.SetActive(true);
        BodY1.GetComponent<SkinnedMeshRenderer>().enabled = true;
        BodY2.GetComponent<SkinnedMeshRenderer>().enabled = true;
        BodY3.GetComponent<SkinnedMeshRenderer>().enabled = true;
        BodY4.GetComponent<SkinnedMeshRenderer>().enabled = true;
        BodY5.GetComponent<SkinnedMeshRenderer>().enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("menuMAIN"))
        {
            if (GameObject.Find("menuMAIN").GetComponent<menu>().MainMenu||GameObject.Find("mainStopMenu"))
            {
                menuPlayer = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }
}
