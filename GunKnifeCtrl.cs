using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GunKnifeCtrl : MonoBehaviour
{
    public PhotonView PTvieW;
    public GameObject MainGun;
    public GameObject SecGun;
    public GameObject Knife;
    public GameObject wMainGun;
    public GameObject wSecGun;
    public GameObject wKnife;
    public int WhatWeapon;
    public GameObject GlwSet;
    public GameObject Glw;
    public GameObject playerW;
    public GameObject ChangeRotateOBJ;
    public GameObject ChangeRotateOBJ1;


    // Start is called before the first frame update
    void Start()
    {
        MainGun.SetActive(false);
        SecGun.SetActive(true);
        Knife.SetActive(false);
        SecGun.GetComponent<shootCtrl>().QieQiang();
        GlwSet.name = SecGun.GetComponent<shootCtrl>().ChildBoneName;
        Glw.GetComponent<Animator>().runtimeAnimatorController = SecGun.GetComponent<Animator>().runtimeAnimatorController;
        WhatWeapon = 2;
    }

    // Update is called once per frame
    public void CleanSmoke()
    {
        if (GameObject.Find("findsmoke"))
        {
            for (int i = 0; i < GameObject.Find("findsmoke").transform.childCount; i++)
            {
                Destroy(GameObject.Find("findsmoke").transform.GetChild(i).gameObject);

            }
        }
    }
        void Update()
        {
            if (PTvieW == false || PTvieW.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && WhatWeapon != 1)
                {
                    if (MainGun)
                    {

                        MainGun.SetActive(true);
                        MainGun.GetComponent<shootCtrl>().isLookingAt = false;
                        MainGun.GetComponent<shootCtrl>().usingScope = false;
                        MainGun.GetComponent<shootCtrl>().useScopeNext = false;
                        SecGun.SetActive(false);
                        Knife.SetActive(false);

                        wMainGun.SetActive(true);
                        wSecGun.SetActive(false);
                        wKnife.SetActive(false);

                        playerW.GetComponent<Animator>().SetInteger("whatWeapon", 2);

                        MainGun.GetComponent<shootCtrl>().QieQiang();
                        GlwSet.name = MainGun.GetComponent<shootCtrl>().ChildBoneName;
                        Glw.GetComponent<Animator>().runtimeAnimatorController = MainGun.GetComponent<Animator>().runtimeAnimatorController;
                        WhatWeapon = 1; CleanSmoke();

                    }

                }
                if (Input.GetKeyDown(KeyCode.Alpha2) && WhatWeapon != 2)
                {
                    if (SecGun)
                    {
                        if (MainGun)
                        {
                            if (MainGun.GetComponent<shootCtrl>().DanDaoTarget)
                            {
                                MainGun.GetComponent<shootCtrl>().DanDaoTarget.GetComponent<DanDaoTargetMovement>().Move = false;
                                MainGun.GetComponent<shootCtrl>().DanDaoTarget2.GetComponent<DanDaoTargetMovement>().Move = false;
                            }
                        }

                        MainGun.SetActive(false);
                        SecGun.SetActive(true);
                        Knife.SetActive(false);
                        SecGun.GetComponent<shootCtrl>().isLookingAt = false;


                        playerW.GetComponent<Animator>().SetInteger("whatWeapon", 1);

                        SecGun.GetComponent<shootCtrl>().QieQiang();
                        GlwSet.name = SecGun.GetComponent<shootCtrl>().ChildBoneName;
                        Glw.GetComponent<Animator>().runtimeAnimatorController = SecGun.GetComponent<Animator>().runtimeAnimatorController;
                        WhatWeapon = 2; CleanSmoke();

                    }

                }
                if (Input.GetKeyDown(KeyCode.Alpha3) && WhatWeapon != 3)
                {
                    if (Knife)
                    {
                        if (MainGun)
                        {
                            if (MainGun.GetComponent<shootCtrl>().DanDaoTarget2)
                            {
                                MainGun.GetComponent<shootCtrl>().DanDaoTarget.GetComponent<DanDaoTargetMovement>().Move = false;
                                MainGun.GetComponent<shootCtrl>().DanDaoTarget2.GetComponent<DanDaoTargetMovement>().Move = false;

                            }
                        }
                        MainGun.SetActive(false);
                        SecGun.SetActive(false);
                        Knife.SetActive(true);

                        wMainGun.SetActive(false);
                        wSecGun.SetActive(false);
                        wKnife.SetActive(true);
                        Knife.GetComponent<shootCtrl>().isLookingAt = false;

                        playerW.GetComponent<Animator>().SetInteger("whatWeapon", 0);


                        GlwSet.name = Knife.GetComponent<shootCtrl>().ChildBoneName;
                        Glw.GetComponent<Animator>().runtimeAnimatorController = Knife.GetComponent<Animator>().runtimeAnimatorController;
                        WhatWeapon = 3;
                        Knife.GetComponent<shootCtrl>().QieQiang(); CleanSmoke();

                    }

                }
            }
            else
            {
                if (playerW.GetComponent<Animator>().GetInteger("whatWeapon") == 1)
                {
                    ChangeRotateOBJ.GetComponent<changeRotate>().changeFtype();
                    ChangeRotateOBJ1.GetComponent<changeRotate>().changeFtype();


                    wMainGun.SetActive(false);
                    wSecGun.SetActive(true);
                    wKnife.SetActive(false);
                }
                if (playerW.GetComponent<Animator>().GetInteger("whatWeapon") == 0)
                {
                    ChangeRotateOBJ.GetComponent<changeRotate>().changeFtype();
                    ChangeRotateOBJ1.GetComponent<changeRotate>().changeFtype();
                    wMainGun.SetActive(false);
                    wSecGun.SetActive(false);
                    wKnife.SetActive(true);

                }
                if (playerW.GetComponent<Animator>().GetInteger("whatWeapon") == 2)
                {
                    ChangeRotateOBJ.GetComponent<changeRotate>().changeSType();
                    ChangeRotateOBJ1.GetComponent<changeRotate>().changeSType();

                    wMainGun.SetActive(true);


                    wSecGun.SetActive(false);
                    wKnife.SetActive(false);

                }
            }
        }

    }
