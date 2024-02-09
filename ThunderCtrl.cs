using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCtrl : MonoBehaviour
{
    public float xMove;
    public float yMove;
    public float zMove;
    public float RangeNum = 2.1f;
    public float TimeThunder;
    public float TimeThunderLimit;
    public float TimeThunderLimitST;
    public float TimeThunderLimitED;
    public float LastTime;

    public GameObject StartOBJ;
    public GameObject EndOBJ;
    public bool Ending;
    // Start is called before the first frame update
    void Start()
    {
        RangeThunder();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeThunder < TimeThunderLimit&&Ending==false)
        {
            EndOBJ.transform.Translate(xMove * Time.deltaTime, yMove * Time.deltaTime, zMove * Time.deltaTime);

        }
        if (TimeThunder >= TimeThunderLimit && Ending == false)
        {
            Ending = true;
            //TimeThunder = 0;
        }
        if (Ending&& TimeThunder < TimeThunderLimit)
        {
            //StartOBJ.transform.Translate(xMove * Time.deltaTime, yMove * Time.deltaTime, zMove * Time.deltaTime);
        }
        if (Ending && TimeThunder >= LastTime )
        {
            Destroy(gameObject);
        }
            TimeThunder = TimeThunder + Time.deltaTime;

    }
    public void RangeThunder()
    {
        xMove = Random.Range(-RangeNum, RangeNum);
        zMove = Random.Range(-RangeNum, RangeNum);
        //yMove = Random.Range(7f, RangeNum * -5);
        yMove = -60;
        //TimeThunderLimit = Random.Range(TimeThunderLimitST, TimeThunderLimitED);
    }
}
