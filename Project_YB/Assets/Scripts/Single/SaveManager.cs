using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data
{
    public TeamData user_team = new TeamData();
    public PlayerData[] player_data = new PlayerData[18];
    public int money;
}

public class SaveManager : MonoBehaviour
{
    
    enum Platform
    {
        PC = 0,
        Android,
    }
    [SerializeField]
    private Platform platform;
    public Data savedata = new();
    

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
        savedata.user_team = GameManager.instance.user_Team;
        for(int i = 0; i < savedata.player_data.Length; i++)
        {
            savedata.player_data[i] = GameManager.instance.user_Team.playerPool[i];
        }
        savedata.money = MoneyManager.instance.GetMoney();
        var jsonSaveData = JsonUtility.ToJson(savedata);

        if (platform == Platform.PC)
        {
            File.WriteAllText("Assets\\data.json", jsonSaveData);
        }
        if (platform == Platform.Android)
        {

        }
    }
    public void LoadGameData()
    {
        if (platform == Platform.PC)
        {
            savedata = JsonUtility.FromJson<Data>(File.ReadAllText("Assets\\data.json"));
        }
        if (platform == Platform.Android)
        {

        }
        GameManager.instance.SetTeam(savedata.user_team);
        for (int i = 0; i < savedata.player_data.Length; i++)
        {
            GameManager.instance.user_Team.playerPool[i] = savedata.player_data[i];
        }
        MoneyManager.instance.SetMoney(savedata.money);

    }
}

