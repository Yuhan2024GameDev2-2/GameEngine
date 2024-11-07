using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorManager : MonoBehaviour
{
    private static ErrorManager _instance;
    public static ErrorManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ErrorManager)) as ErrorManager;
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
    }

    public void Error_CYS(int errorcode)
    {
        string message = "NO_ERROR_MESSAGE";
        string code = "ErrorCode : " + errorcode + " / ";

        switch (errorcode)
        {
            case 0:
                message = "뭔가오류";
                break;
            case 1:
                message = "비정상적인 플랫폼에서 실행되었습니다.";
                break;
            case 2:
                message = "인덱스 범위 벗어남";
                break;
        }

        Debug.Log(code + message); 
        //Application.Quit();
    }
}
