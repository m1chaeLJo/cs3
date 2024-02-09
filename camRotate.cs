using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class camRotate : MonoBehaviour
{
    public PhotonView Pview;

    public bool DontChangeParentsRotation;
    //public NetworkTransform Nt;
    // ˮƽ�ӽ��ƶ������ж�
    public float sensitivityHor = 3f;
    // ��ֱ�ӽ��ƶ������ж�
    public float sensitivityVer = 3f;
    // �ӽ������ƶ��ĽǶȷ�Χ����ֵԽС��ΧԽ��
    public float upVer = -85;
    // �ӽ������ƶ��ĽǶȷ�Χ����ֵԽ��ΧԽ��
    public float downVer = 85;
    // ��ֱ��ת�Ƕ�
    private float rotVer;
    public GameObject Cam;
    // ��ת�ķ�������
    // x ��ʾ�� x ����ת���� ǰ�Ϻ� �ĽǶ�
    // y ��ʾ�� y ����ת���� ��ǰ�� �ĽǶ�
    // y ��ʾ�� y ����ת���� ��ǰ�� �ĽǶ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ����ǰ�Ĵ�ֱ�Ƕ�
        rotVer = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pview == false || Pview.IsMine)
        {
            // ��ȡ������µ��ƶ�λ��
            float mouseVer = Input.GetAxis("Mouse Y");
            // ��ȡ������ҵ��ƶ�λ��
            float mouseHor = Input.GetAxis("Mouse X");
            // ��������ƶ����ӽ���ʵ�������ƣ�����Ҫ��ﵽ�ӽ�Ҳ�����ƵĻ�����Ҫ��ȥ��
            rotVer -= mouseVer * sensitivityVer;
            // �޶������ƶ����ӽǷ�Χ������ֱ������360����ת
            rotVer = Mathf.Clamp(rotVer, upVer, downVer);
            // �����ӽǵ��ƶ�ֵ
            transform.localEulerAngles = new Vector3(rotVer, 0, 0);//����������������ӽ��ƶ�����Ҳ�����
            if (DontChangeParentsRotation) return;
            transform.parent.Rotate(Vector3.up * mouseHor);//ת����ҵ�ˮƽ�ӽ��ƶ��������Ҳ�ᶯ��
        }
        else
        {
            //Cam.SetActive(false);
        }
            
    }


}



