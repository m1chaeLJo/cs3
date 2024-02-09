using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanDaoTargetMovement : MonoBehaviour
{
    public GameObject TargetOBJs;
    public bool isSmoothMovement;
    public int BulletNum;
    //public int MaxBullet;
    public int ReUseBulletNum;
    public float MoveSpeedMoveToward;
    public float MoveSpeedLerp;

    public float LerpTime;
    public float Time_;

    public bool Move;
    public bool Shoot;
    public bool isCtrlShootNext;
    public GameObject GunCtrl;
    // Start is called before the first frame update
    void Start()
    {
        BulletNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Move)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, TargetOBJs.transform.position, MoveSpeedMoveToward * Time.deltaTime);

        }
        Time_ = Time_ + Time.deltaTime;
        if (Move)
        {
            MoveToNextTarget();
        }
        if (Shoot)
        {
            Shoot = false;
            ReadyToShoot();
        }
    }

    public void ReadyToShoot()
    {
        Time_ = 0;
        BulletNum++;
        if (BulletNum > TargetOBJs.transform.childCount)
        {
            BulletNum = ReUseBulletNum;
        }
        if (isSmoothMovement)
        {
            gameObject.transform.position = TargetOBJs.transform.GetChild(BulletNum - 1).position;

        }
        if (isCtrlShootNext)
        {
            GunCtrl.GetComponent<shootCtrl>().GunShoot();

        }
    }
    public void MoveToNextTarget()
    {
        if (isSmoothMovement)
        {
            if (Move)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, TargetOBJs.transform.GetChild(BulletNum).position, MoveSpeedMoveToward * Time.deltaTime);

            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, TargetOBJs.transform.position, MoveSpeedMoveToward * Time.deltaTime);
            }

        }
        else
        {
            if (Time_ < LerpTime)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, TargetOBJs.transform.GetChild(BulletNum).position, MoveSpeedLerp * Time.deltaTime);
            }
            else
            {
                //Debug.Log("1");
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, TargetOBJs.transform.position, MoveSpeedMoveToward * Time.deltaTime);
            }
        }
    }
}
