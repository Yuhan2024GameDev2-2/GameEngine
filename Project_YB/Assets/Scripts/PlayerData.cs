using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData : MonoBehaviour
{
    public enum injury_Type
    {
        None = 0,
        피곤,
        감기,
        슬럼프,
    }

    int id = -1;
    int backnumber = -1;

    int price = -1;

    string firstName = "John";
    string lastName = "Doe";

    int attack = -1;
    int attack_Max = 1000;

    int defend = -1;
    int defend_Max = 1000;

    injury_Type[] injuryPool = new injury_Type[5];
    int[] injury_duration = new int[5];

    //Rendering
    int hair_Type;
    int head_Type;
    int body_Type;

}
