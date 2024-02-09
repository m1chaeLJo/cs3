using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootCtrl : MonoBehaviour
{
    public GameObject Cam; public GameObject hitRay;

    public float damageOfWeapon;
    public float Distancmax;
    public float time;
    public int bullet;
    public float TimeLastShoot;
    public float TimeCanShoot;
    public Animator AniWeaponsGUN;
    public Animator AniWeaponsGlw;
    public string ChildBoneName;
    public bool isSHooting;
    public bool LTN;
    public bool isLookingAt;

    public int _FieldOfView = 45;

    public GameObject _scope;
    public GameObject crosshair;
    public bool useScope;
    public bool usingScope;
    public bool useScopeNext;
    public GameObject MainCam;
    public GameObject rotateCam;

    public GameObject SudDraw;
    public GameObject SudShoot;
    public GameObject SudDraw2;
    public GameObject SudLook1;
    public GameObject SudLook2;
    public GameObject SudScope;
    public GameObject SudReload;

    public GameObject DanDaoTarget;
    public GameObject DanDaoTarget2;
    void Start()
    {
        isSHooting = true;
        TimeLastShoot = 0;
        _scope = GameObject.Find("scope");
        crosshair = GameObject.Find("crosshair");



    }
    public void GunShoot()
    {
        Instantiate(SudShoot, transform.parent.transform);
        usingScope = false;
        if (LTN)
        {
            int radomi = Random.Range(1, 4);
            if (radomi == 1)
            {
                if (GameObject.Find("p_167_WebLightingPack"))
                {
                    GameObject.Find("p_167_WebLightingPack").GetComponent<lightningStrike>().StartTime = 0;
                    GameObject.Find("p_167_WebLightingPack").GetComponent<lightningStrike>().isLightning = true;

                }
            }
            else if (radomi == 2)
            {
                if (GameObject.Find("p_167_WebLightingPack (1)"))
                {
                    GameObject.Find("p_167_WebLightingPack (1)").GetComponent<lightningStrike>().StartTime = 0;
                    GameObject.Find("p_167_WebLightingPack (1)").GetComponent<lightningStrike>().isLightning = true;

                }
            }
            else if (radomi == 3)
            {
                if (GameObject.Find("p_167_WebLightingPack (2)"))
                {
                    GameObject.Find("p_167_WebLightingPack (2)").GetComponent<lightningStrike>().StartTime = 0;
                    GameObject.Find("p_167_WebLightingPack (2)").GetComponent<lightningStrike>().isLightning = true;

                }
            }

            //gameObject.GetComponent<CreateThunder>().CreateT();
            gameObject.GetComponent<CreateThunder>().AwakeTime = 0;
        }
        if (gameObject.GetComponent<SetSmoke>())
        {
            gameObject.GetComponent<SetSmoke>().SetSmokeNow();
        }

        AniWeaponsGUN.SetInteger("State", 1);
        AniWeaponsGUN.SetBool("isShooting", true);
        AniWeaponsGlw.SetInteger("State", 1);
        AniWeaponsGlw.SetBool("isShooting", true);
        isSHooting = true;
        TimeLastShoot = 0;
        Cam.GetComponent<bulletHitRay>().FullDam = damageOfWeapon;
        Cam.GetComponent<bulletHitRay>().DistanceMax = Distancmax;

        Cam.GetComponent<bulletHitRay>().ShootRay();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            if (DanDaoTarget)
            {
                DanDaoTarget.GetComponent<DanDaoTargetMovement>().Move = false;
                DanDaoTarget.GetComponent<DanDaoTargetMovement>().BulletNum = 0;
            }
            
        }
        if (!Input.GetMouseButton(0))
        {
            if (DanDaoTarget2)
            {
                DanDaoTarget2.GetComponent<DanDaoTargetMovement>().Move = false;
                DanDaoTarget2.GetComponent<DanDaoTargetMovement>().BulletNum = 0;
            }
        }
        AnimatorStateInfo stateinfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);   // 参数表示动画层的id

        TimeLastShoot = TimeLastShoot + Time.deltaTime;
        if (isSHooting)
        {
            AniWeaponsGUN.SetInteger("State", 0);
            AniWeaponsGUN.SetBool("isShooting", false);
            AniWeaponsGlw.SetInteger("State", 0);
            AniWeaponsGlw.SetBool("isShooting", false);
        }
        if (!GameObject.Find("mainStopMenu"))
        {
            if (Input.GetMouseButton(0) && TimeLastShoot >= TimeCanShoot)
            {
                if (stateinfo.IsName("draw") == false&&stateinfo.IsName("draw 0") == false)
                {
                    if (DanDaoTarget)
                    {
                        DanDaoTarget.GetComponent<DanDaoTargetMovement>().ReadyToShoot();
                        DanDaoTarget.GetComponent<DanDaoTargetMovement>().Move = true; 
                        DanDaoTarget2.GetComponent<DanDaoTargetMovement>().ReadyToShoot();
                        DanDaoTarget2.GetComponent<DanDaoTargetMovement>().Move = true;
                    }
                    else
                    {
                        GunShoot();

                    }

                }

            }

        }
        if (Input.GetKeyDown(KeyCode.F) && TimeLastShoot >= TimeCanShoot)
        {
            if (!stateinfo.IsName("F") && !stateinfo.IsName("F 0"))
            {
                isLookingAt = true;
                int i = Random.Range(0, 8);
                AniWeaponsGUN.SetInteger("random", i);
                AniWeaponsGlw.SetInteger("random", i);
                AniWeaponsGUN.SetInteger("State", 2);
                AniWeaponsGlw.SetInteger("State", 2);
                if (SudLook1)
                {
                    if (i < 2)
                    {
                        Instantiate(SudLook1, transform);
                    }
                    else
                    {
                        Instantiate(SudLook2, transform);

                    }


                }
            }

        }


        if (stateinfo.IsName("F") || stateinfo.IsName("F 0"))
        {
            isLookingAt = false;
        }
        else if (isLookingAt)
        {
            AniWeaponsGUN.SetInteger("State", 2);
            AniWeaponsGlw.SetInteger("State", 2);
        }
        if (Input.GetKeyDown(KeyCode.R) & TimeLastShoot >= TimeCanShoot)
        {
            if (SudReload)
            {
                AniWeaponsGUN.SetInteger("State", 3);
                AniWeaponsGlw.SetInteger("State", 3);
                Instantiate(SudReload, transform);
            }


        }

    }

    public void AfterShootOpenScope()
    {
        if (useScopeNext)
        {
            usingScope = true;
        }
    }
    void LateUpdate()
    {
        if (AniWeaponsGlw.GetInteger("State") == -1)
        {
            AniWeaponsGUN.SetInteger("State", 0);
            AniWeaponsGlw.SetInteger("State", 0);
        }
        if (useScope)
        {
            for (int i = 0; i < crosshair.GetComponentsInChildren<Image>().Length; i++)
            {
                crosshair.GetComponentsInChildren<Image>()[i].enabled = false;

            }
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(SudScope, transform);
                if (usingScope)
                {
                    usingScope = false;
                    useScopeNext = false;
                }
                else
                {

                    usingScope = true;
                    useScopeNext = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < crosshair.GetComponentsInChildren<Image>().Length; i++)
            {
                crosshair.GetComponentsInChildren<Image>()[i].enabled = true;

            }
            MainCam.GetComponent<Camera>().fieldOfView = _FieldOfView;
            rotateCam.GetComponent<CPMPlayer>().xMouseSensitivity = 30;
            rotateCam.GetComponent<CPMPlayer>().yMouseSensitivity = 30;


            usingScope = false;
        }
        AnimatorStateInfo stateinfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);   // 参数表示动画层的id
        //Debug.Log(stateinfo.IsName("idle"));
        if (stateinfo.IsName("idle") == false)
        {
            usingScope = false;

        }
        else
        {
            if (useScopeNext)
            {
                usingScope = true;
            }
        }
        if (usingScope)
        {
            MainCam.GetComponent<Camera>().fieldOfView = 20;
            rotateCam.GetComponent<CPMPlayer>().xMouseSensitivity = 13;
            rotateCam.GetComponent<CPMPlayer>().yMouseSensitivity = 13;
            for (int i = 0; i < _scope.GetComponentsInChildren<Image>().Length; i++)
            {
                _scope.GetComponentsInChildren<Image>()[i].enabled = true;

            }
        }
        else
        {
            MainCam.GetComponent<Camera>().fieldOfView = _FieldOfView;
            rotateCam.GetComponent<CPMPlayer>().xMouseSensitivity = 30;
            rotateCam.GetComponent<CPMPlayer>().yMouseSensitivity = 30;
            for (int i = 0; i < _scope.GetComponentsInChildren<Image>().Length; i++)
            {
                _scope.GetComponentsInChildren<Image>()[i].enabled = false;

            }
        }
    }
    public void shootBullet(int isShoot)
    {
        if (isShoot == 1)
        {
            time = time + 1;
        }
    }
    public void QieQiang()
    {
        int i = Random.Range(0, 8);

        AniWeaponsGUN.SetInteger("State", -1);
        AniWeaponsGlw.SetInteger("State", -1);
        AniWeaponsGUN.SetInteger("random", i);
        AniWeaponsGlw.SetInteger("random", i);
        for (int n = 0; n < gameObject.transform.childCount; n++)
        {
            if (transform.GetChild(n).tag == "sound")
            {
                Destroy(transform.GetChild(n).gameObject);
                Debug.Log("destroy" + transform.GetChild(n).name);
            }

        }

        if (SudDraw2)
        {

            if (i < 2)
            {
                Instantiate(SudDraw, transform);
            }
            else
            {
                Instantiate(SudDraw2, transform);

            }
        }
        else
        {
            Instantiate(SudDraw, transform);
        }
    }
}
