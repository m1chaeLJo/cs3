using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class move : MonoBehaviour
{
    public PhotonView PTview;
    //public float AddSpeedPrecent;
    public CharacterController c;
    //public NetworkCharacterControllerPrototype cN;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 moveDirectionJump = Vector3.zero;

    public Animator ANI;

    public Vector3 moveDirectionD = Vector3.zero;
    public float AddSpeed;
    public float moveSpeed, jumpSpeed = 1;
    public float moveSpeedf;
    public float moveSpeedr;
    public float gravity = 9.8f;
    public float h, v;
    public float MaxSpeed;
    public float lasth;
    public float lastv;
    public bool isMoveAniPlay;
    public float RotateJumpSpeedAmount;
    public bool LastSecOnGround;

    public Animator AniOfPlayerModel;
    //public static float Abs(float f);
    void Start()
    {
        //PTview = GameObject.Find("menu").GetComponent<PhotonView>();
        moveSpeed = 0;

        c = GetComponent<CharacterController>();
        //cN = GetComponent<NetworkCharacterControllerPrototype>();
    }
    void Update()
    {
        if (PTview==false|| PTview.IsMine)
        {
            if (c.isGrounded)
            {
                AniOfPlayerModel.SetBool("onGround", true);
                LastSecOnGround = true;

                h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");

                if (h != 0 || v != 0)
                {
                    moveSpeed = moveSpeed + AddSpeed * Time.deltaTime;
                }
                else
                {
                    moveSpeed = 0;
                }
                if (lasth > 0 && h < 0)
                {
                    moveSpeed = 0;
                }
                if (lastv > 0 && v < 0)
                {
                    moveSpeed = 0;
                }
                if (lasth < 0 && h > 0)
                {
                    moveSpeed = 0;
                }
                if (lastv < 0 && v > 0)
                {
                    moveSpeed = 0;
                }

                //moveSpeedr = h * AddSpeed;
                //moveSpeedf = v * AddSpeed;
                //moveSpeed = Mathf.Sqrt(moveSpeedf * moveSpeedf + moveSpeedr * moveSpeedr);
                if (moveSpeed > MaxSpeed)
                {
                    moveSpeed = MaxSpeed;
                }
                if (moveSpeed < -MaxSpeed)
                {
                    moveSpeed = -MaxSpeed;
                }
                if (moveSpeedr > MaxSpeed)
                {
                    moveSpeedr = MaxSpeed;
                }
                if (moveSpeedr < -MaxSpeed)
                {
                    moveSpeedr = -MaxSpeed;
                }
                if (moveSpeedf > MaxSpeed)
                {
                    moveSpeedf = MaxSpeed;
                }
                if (moveSpeedf < -MaxSpeed)
                {
                    moveSpeedf = -MaxSpeed;
                }
                lasth = h;
                lastv = v;

                moveDirection = (transform.right * h + transform.forward * v).normalized;
                moveDirectionJump = moveDirection;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirectionD.y = jumpSpeed;
                }
            }
            else
            {
                AniOfPlayerModel.SetBool("onGround", false);

                LastSecOnGround = false;

                h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");

                if (h != 0 || v != 0)
                {
                    moveSpeed = moveSpeed + AddSpeed;
                }
                else
                {
                    moveSpeed = 0;
                }
                //moveSpeedr = lasth * AddSpeed;
                //moveSpeedf = lastv * AddSpeed;
                //moveSpeed = Mathf.Sqrt(moveSpeedf * moveSpeedf + moveSpeedr * moveSpeedr);
                if (moveSpeed > MaxSpeed)
                {
                    moveSpeed = MaxSpeed;
                }
                if (moveSpeed < -MaxSpeed)
                {
                    moveSpeed = -MaxSpeed;
                }
                if (moveSpeedr > MaxSpeed)
                {
                    moveSpeedr = MaxSpeed;
                }
                if (moveSpeedr < -MaxSpeed)
                {
                    moveSpeedr = -MaxSpeed;
                }
                if (moveSpeedf > MaxSpeed)
                {
                    moveSpeedf = MaxSpeed;
                }
                if (moveSpeedf < -MaxSpeed)
                {
                    moveSpeedf = -MaxSpeed;
                }

                if (lasth + h * 0.5f > 1)
                {
                    if (lastv + v > 1)
                    {
                        moveDirection = (transform.right * 1 + transform.forward * 1).normalized;
                    }
                    else
                    {
                        moveDirection = (transform.right * 1 + transform.forward * (lastv + v * RotateJumpSpeedAmount)).normalized;
                    }
                }
                else
                {
                    if (lastv + v * 0.5f > 1)
                    {
                        moveDirection = (transform.right * (lasth + h * RotateJumpSpeedAmount) + transform.forward * 1).normalized;
                    }
                    else
                    {
                        moveDirection = (transform.right * (lasth + h * RotateJumpSpeedAmount) + transform.forward * (lastv + v * RotateJumpSpeedAmount)).normalized;
                    }
                }


            }

            if (moveSpeed > 0 & isMoveAniPlay == false)
            {
                ANI.SetBool("IsMove", true);
                isMoveAniPlay = true;
            }
            if (moveSpeed < MaxSpeed & isMoveAniPlay == true)
            {
                ANI.SetBool("IsMove", false);
                isMoveAniPlay = false;
            }
            if (c.isGrounded == false)
            {
                ANI.SetBool("IsMove", false);
                isMoveAniPlay = false;
            }
            if (c.isGrounded && moveDirectionD.y < 0)
            {
                moveDirectionD.y = 0;

            }
            moveDirectionD.y -= gravity * Time.deltaTime;

            //c.Move(moveDirection * moveSpeed * Time.dceltaTime);
            //c.Move(moveDirectionD * 1 * Time.deltaTime);

            AniOfPlayerModel.SetFloat("NS", v * moveSpeed / MaxSpeed);
            AniOfPlayerModel.SetFloat("WE", -h * moveSpeed / MaxSpeed);
        }
        
    }

}
