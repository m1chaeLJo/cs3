using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerHP : MonoBehaviour
{
    public float Health;
    public GameObject ragdollCtrl;
    private PhotonView photonView;
    public GameObject CamOfEnemy;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (Health == 0)
        {
            ragdollCtrl.GetComponent<ragdollCtrl>().EnableRagdoll();
        }
    }
    public void TakeDamage(float _damage)
    {
        photonView.RpcSecure("RPC_takeDamage", RpcTarget.All, true, _damage);
    }
    [PunRPC]
    private void RPC_takeDamage(float _damage, PhotonMessageInfo info)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            Health = 0;

            ragdollCtrl.GetComponent<ragdollCtrl>().EnableRagdoll();
            

        }
    }
}
