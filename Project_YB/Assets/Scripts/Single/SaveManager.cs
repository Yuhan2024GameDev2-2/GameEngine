using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    
    enum Platform
    {
        PC = 0,
        Android,
    }
    [SerializeField]
    private Platform platform;

    private static SaveManager _instance;
    public static SaveManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(SaveManager)) as SaveManager;
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //awake시 플랫폼 선택됨
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            platform = Platform.PC;
        else if (Application.platform == RuntimePlatform.Android)
            platform = Platform.Android;
        else
            ErrorManager.instance.Error_CYS(1);
    }

    public void SaveGameData()
    {
        if (platform == Platform.PC)
        {

        }
        if (platform == Platform.Android)
        {

        }
    }
    public void LoadGameData()
    {
        if (platform == Platform.PC)
        {

        }
        if (platform == Platform.Android)
        {

        }
    }
}

