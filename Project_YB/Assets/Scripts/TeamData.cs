using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class TeamData : MonoBehaviour
{
    int backNumber;
    string firstName;
    string lastName;

    public PlayerData[] playerPool = new PlayerData[18];
    public PlayerData p1 = new PlayerData();

    public int AddPlayer(PlayerData player)
    {

        for (int i = 0; i < playerPool.Length; i++)
        {
            if (playerPool[i] == null)
            {
                playerPool[i] = new PlayerData();
                return 0;
            }
            if(i == playerPool.Length - 1)
            {
                return -1;
            }
        }
        return -1;
    }
    
    public int removePlayer(int outIndex)
    {
        if(outIndex>17)
        {
            ErrorManager.instance.Error_CYS(2);
            return -1;
        }

        playerPool[outIndex] = null;

        for(int i = outIndex; i < playerPool.Length; i++)
        {
            if(i<17)
            playerPool[i] = playerPool[i + 1];
            else
            playerPool[17] = null;
        }

        return 0;
    }

}
