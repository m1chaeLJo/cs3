using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class testPUN : MonoBehaviour
{
    public Vector3 TstVector;
    public GameObject TstObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<PhotonView>().RpcSecure("RPCtest", RpcTarget.All, true, TstObj);
    }
    [PunRPC]
    private void RPCtest(Vector3 TestV3,GameObject TSTGmOBJ, PhotonMessageInfo info)
    {

    }
}
