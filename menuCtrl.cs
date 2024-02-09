using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("menuMAIN"))
        {
 if (!GameObject.Find("menuMAIN").GetComponent<menu>().MainMenu && !GameObject.Find("mainStopMenu"))
        {
        Cursor.lockState = CursorLockMode.Locked;

        }
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (Input.GetKey(KeyCode.LeftControl))

            {
#if UNITY_EDITOR //编辑器中退出游戏
                UnityEditor.EditorApplication.isPlaying = false;
#else //应用程序中退出游戏
	UnityEngine.Application.Quit();
#endif
            }

        }

    }
}
