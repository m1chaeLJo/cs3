using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public int A;
    public GameObject MainMenu;
    public GameObject MenuPlayer;
    public RenderTexture Blurtex;
    public Camera TargetCam;
    public GameObject stopMenu;
    public bool isstopped;
    public TMP_Dropdown SetQualityUi;
    public int DropDownNumber;

    public GameObject reflectionVolume;
    public GameObject RTXVolume;
    public Volume  noneVolume;

    public GameObject ReflecUi;

    public Volume ReflecV;
    public Volume RTXV;
    
    //public space


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("menu"))
        {
        GameObject.Find("menu").GetComponent<ConnectAndJoinRandom>().OnJoinedRoom();

        }

        SetQualityUi = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        stopMenu = GameObject.Find("mainStopMenu");
        ReflecUi = GameObject.Find("DropdownReflection");
        reflectionVolume = GameObject.Find("simpleReflection");
        RTXVolume = GameObject.Find("RTX");
        ReflecV = reflectionVolume.GetComponent<Volume>();
        RTXV = RTXVolume.GetComponent<Volume>();
        noneVolume = GameObject.Find("none").GetComponent<Volume>();

        DisableStopMenu();
        isstopped = false;
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"), true);

        if (PlayerPrefs.GetInt("reflection") == 0)
        {
            ReflecV.enabled = false;
            RTXV.enabled = false;
            noneVolume.enabled = true;

        }
        if (PlayerPrefs.GetInt("reflection") == 1)
        {
            ReflecV.enabled = true;
            RTXV.enabled = false;
            noneVolume.enabled = false;

        }
        if (PlayerPrefs.GetInt("reflection") == 2)
        {
            ReflecV.enabled = false;
            RTXV.enabled = true;
            noneVolume.enabled = false;

        }
        switch (PlayerPrefs.GetInt("Resolution"))
        {
            case 0:
                Screen.SetResolution(848, 480, true);

                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 3:
                Screen.SetResolution(4096, 2160, true);
                break;
            case 4:
                Screen.SetResolution(7680, 4320, true);
                break;

        }

    }
    public void ShowStopMenu()
    {
        if (MainMenu)
        {
            MainMenu.SetActive(false);
        }

        stopMenu.SetActive(true);
        if (TargetCam)
        {
            TargetCam.targetTexture = Blurtex;

        }
        if (PlayerPrefs.GetInt("Quality") == 0)
        {
            SetQualityUi.value = 0;

        }
        if (PlayerPrefs.GetInt("Quality") == 1)
        {
            SetQualityUi.value = 1;

        }
        if (PlayerPrefs.GetInt("Quality") == 2)
        {
            SetQualityUi.value = 2;

        }
        if (PlayerPrefs.GetInt("reflection") == 0)
        {
            GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value = 0;

        }
        if (PlayerPrefs.GetInt("reflection") == 1)
        {
            GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value = 1;

        }
        if (PlayerPrefs.GetInt("reflection") == 2)
        {
            GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value = 2;

        }
        GameObject.Find("DropdownResolution").GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("Resolution");
    }
    public void DisableStopMenu()
    {
        if (MainMenu)
        {
            MainMenu.SetActive(true);

        }

        stopMenu.SetActive(false);
        if (TargetCam)
        {
            TargetCam.targetTexture = null;

        }
    }
    void Update()
    {
        if (GameObject.Find("CameraMenu"))
        {
            TargetCam = GameObject.Find("CameraMenu").GetComponent<Camera>();


        }
        if (TargetCam == false && GameObject.FindWithTag("MainCamera"))
        {
            TargetCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isstopped)
            {
                isstopped = false;
                DisableStopMenu();
            }
            else
            {
                isstopped = true;
                ShowStopMenu();

            }
        }
    }
    // Update is called once per frame
    public void SetQuality()
    {
        Debug.Log("setQuality");
        //Debug.Log("1");
        //
        //Debug.Log("2");
        //QualitySettings.SetQualityLevel(3, true);
        //Debug.Log("3");
        if (SetQualityUi.value == 0)
        {
            PlayerPrefs.SetInt("Quality", 0);
            QualitySettings.SetQualityLevel(0, true);
        }
        if (SetQualityUi.value == 1)
        {
            PlayerPrefs.SetInt("Quality", 1);

            QualitySettings.SetQualityLevel(1, true);
        }
        if (SetQualityUi.value == 2)
        {
            PlayerPrefs.SetInt("Quality", 2);

            QualitySettings.SetQualityLevel(2, true);
        }
    }
    public void SetResolution()
    {
        switch (GameObject.Find("DropdownResolution").GetComponent<TMP_Dropdown>().value)
        {
            case 0:
                Screen.SetResolution(848, 480, true);

                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 3:
                Screen.SetResolution(4096, 2160, true);
                break;
            case 4:
                Screen.SetResolution(7680, 4320, true);
                break;
        }
        PlayerPrefs.SetInt("Resolution", GameObject.Find("DropdownResolution").GetComponent<TMP_Dropdown>().value);
    }
    public void SetReflec()
    {
        Debug.Log("setReflect");

        if (ReflecUi)
        {
            DropDownNumber = GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value;

        }
        else
        {
            Debug.Log("nope");

        }
        if (GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value == 0)
        {
            PlayerPrefs.SetInt("reflection", 0);
            ReflecV.enabled = false;
            RTXV.enabled = false;
            noneVolume.enabled = true;
        }
        if (GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value == 1)
        {
            PlayerPrefs.SetInt("reflection", 1);

            ReflecV.enabled = true;

            RTXV.enabled = false; noneVolume.enabled = false;
        }
        if (GameObject.Find("DropdownReflection").GetComponent<TMP_Dropdown>().value == 2)
        {
            PlayerPrefs.SetInt("reflection", 2);

            ReflecV.enabled = false; 
            noneVolume.enabled = false;

            RTXV.enabled = true;

        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR //编辑器中退出游戏
        UnityEditor.EditorApplication.isPlaying = false;
#else //应用程序中退出游戏
	UnityEngine.Application.Quit();
#endif
    }
    public void BackToMenu()
    {
        if (GameObject.FindWithTag("Player"))
        {
            Destroy(GameObject.FindWithTag("Player"));
        }
        SceneManager.LoadScene("main");

        
    }
    public void Dust2()
    {
        Destroy(MenuPlayer);
        SceneManager.LoadScene("DUST2");
        A++;
        Destroy(MenuPlayer);
    }
    public void Dust3()
    {
        Destroy(MenuPlayer);
        SceneManager.LoadScene("DUST3");
    }
    public void hill()
    {
        Destroy(MenuPlayer);
        SceneManager.LoadScene("hill");
    }
    public void inferno()
    {
        Destroy(MenuPlayer);
        SceneManager.LoadScene("INFERNO");
    }
}
