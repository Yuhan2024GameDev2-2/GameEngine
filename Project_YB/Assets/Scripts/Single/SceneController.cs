using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// 빌드할때 씬번호와 동일하게 맞춰야됨
    /// </summary>
    public enum SceneNum
    {
        Title = 0,      //타이틀 화면
        Main = 1,       //메인화면
    }
    private static SceneController _instance;
    public static SceneController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(SceneController)) as SceneController;
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


    /// <summary>
    /// Scene 전환 함수
    /// </summary>
    /// <param name="SceneNumber"> SceneController가 가지는 씬 번호 enum</param>
    public void GoToScene(SceneNum SceneNumber)
    {
        SceneManager.LoadScene((int)SceneNumber);
        /*
         * 인스펙터에서 enum값을 집어넣을 수 있으면 편할 것 같음. 나중에 추가할 지 생각해 보자
         * https://github.com/NK-Studio/Visible-Enum-Attribute?tab=readme-ov-file 
         */
    }
    public void GoToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void GoToScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
