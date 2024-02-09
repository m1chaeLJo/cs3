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
                //�ų�����״̬��Rigidbody
                continue;
            }
            //���Rigidbody��Collider��List
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

        //����������״̬������Rigidbody��Collider
        for (int i = 0; i < RagdollRigidbodys.Count; i++)
        {
            RagdollRigidbodys[i].isKinematic = false;
            RagdollColliders[i].isTrigger = false;
        }
        //�ر�����״̬��Collider
        //GetComponent<Collider>().enabled = false;
        //��һ֡�ر�����״̬�Ķ���ϵͳ
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

        
        //�رղ�����״̬������Rigidbody��Collider
        for (int i = 0; i < RagdollRigidbodys.Count; i++)
        {
            RagdollRigidbodys[i].isKinematic = true;
            RagdollColliders[i].isTrigger = true;
        }
        //��������״̬��Collider
        //GetComponent<Collider>().enabled = true;
        //��һ֡��������״̬�Ķ���ϵͳ
        StartCoroutine(SetAnimatorEnable(true));
        

    }
    
    IEnumerator SetAnimatorEnable(bool Enable)
    {
        yield return new WaitForEndOfFrame();
        Anim.enabled = Enable;
    }
    
}
