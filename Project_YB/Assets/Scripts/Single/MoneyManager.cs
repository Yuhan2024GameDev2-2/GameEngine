using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private static int Money;
    private static MoneyManager _instance;
    public static MoneyManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MoneyManager)) as MoneyManager;
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

    public void IncressMoney(int moneyInput)
    {
        Money = Money + moneyInput;
    }
    public void DecressMoney(int moneyInput)
    {
        Money = Money - moneyInput;
    }
    public string GetMoney()
    {
        return Money.ToString() + "만";
    }
}
