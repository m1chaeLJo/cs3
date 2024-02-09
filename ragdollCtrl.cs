using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using Photon.Pun;
public class ragdollCtrl : MonoBehaviour
{
    public Vector3 Up_;
    public List<Rigidbody> RagdollRigidbodys = new List<Rigidbody>();
    public List<Collider> RagdollColliders = new List<Collider>();
    public Animator Anim;
    public bool IsRagdollActive;
    public GameObject _parent;
    public GameObject CtrlCam;
    public GameObject CtrlGUnChange;


    public GameObject mainCam;
    private void Start()
    {

        InitRagdoll();
        DisableRagdoll();
    }
    public void InitRagdoll()
    {
        Rigidbody[] Rigidbodys = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < Rigidbodys.Length; i++)
        {
            if (Rigidbodys[i] == GetComponent<Rigidbody>())
            {
                //排除正常状态的Rigidbody
                continue;
            }
            //添加Rigidbody和Collider到List
            RagdollRigidbodys.Add(Rigidbodys[i]);
            Rigidbodys[i].isKinematic = true;
            Collider RagdollCollider = Rigidbodys[i].gameObject.GetComponent<Collider>();
            RagdollCollider.isTrigger = true;
            RagdollColliders.Add(RagdollCollider);
        }
    }
    public void EnableRagdoll()
    {
        _parent = transform.parent.gameObject;

        //开启布娃娃状态的所有Rigidbody和Collider
        for (int i = 0; i < RagdollRigidbodys.Count; i++)
        {
            RagdollRigidbodys[i].isKinematic = false;
            RagdollColliders[i].isTrigger = false;
        }
        //关闭正常状态的Collider
        //GetComponent<Collider>().enabled = false;
        //下一帧关闭正常状态的动画系统
        StartCoroutine(SetAnimatorEnable(false));
        IsRagdollActive = true;
        transform.parent = null;
        _parent.GetComponent<CharacterController>().enabled = false;
        CtrlCam.GetComponent<camRotate>().enabled = false;
        CtrlCam.SetActive(false);
        CtrlGUnChange.SetActive(false);
        CtrlGUnChange.GetComponent<GunKnifeCtrl>().enabled = false;
        //_parent.SetActive(false);
        _parent.GetComponent<NetViewOrNot>().aLLview();
        Destroy(_parent);
        if(gameObject.GetComponent<PhotonView>().IsMine)
        {
        GameObject.Find("menu").GetComponent<ConnectAndJoinRandom>().OnJoinedRoom();

        }
        mainCam.GetComponent<bulletHitRay>().isForceNeeded = true;
        Destroy(gameObject, 15f);
        transform.Translate(Up_, Space.World);

    }
    
    public void DisableRagdoll()
    {

        
        //关闭布娃娃状态的所有Rigidbody和Collider
        for (int i = 0; i < RagdollRigidbodys.Count; i++)
        {
            RagdollRigidbodys[i].isKinematic = true;
            RagdollColliders[i].isTrigger = true;
        }
        //开启正常状态的Collider
        //GetComponent<Collider>().enabled = true;
        //下一帧开启正常状态的动画系统
        StartCoroutine(SetAnimatorEnable(true));
        

    }
    
    IEnumerator SetAnimatorEnable(bool Enable)
    {
        yield return new WaitForEndOfFrame();
        Anim.enabled = Enable;
    }
    
}
