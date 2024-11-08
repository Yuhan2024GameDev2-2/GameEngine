using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// GameManager.instance 로 어디서든 사용 가능!
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public TeamData user_Team;

    public void KickPlayerFromTeam(int index)
    {
        user_Team.removePlayer(index);
    }
    public void SetTeam(TeamData input)
    {
        user_Team.SetTeamData(input);
    }

    public void ExitGame()
    {
        SaveManager.instance.SaveGameData();
        Application.Quit();
    }
}
