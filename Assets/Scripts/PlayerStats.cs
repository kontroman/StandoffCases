using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get;private set; }

    private float _silverCount;
    private float _goldCount;

    public float SilverCount
    {
        get { return _silverCount; }
        set
        {
            if (this._silverCount != value)
            {
                this._silverCount = value;
                OnSilverChanged?.Invoke(value);
            }
        }
    }
    public float GoldCount
    {
        get { return _goldCount; }
        set
        {
            if (this._goldCount != value)
            {
                this._goldCount = value;
                OnGoldChanged?.Invoke(value);
            }
        }
    }

    public event Action<float> OnSilverChanged;
    public event Action<float> OnGoldChanged;


    private void Awake()
    {
        Instance = this;

        SilverCount = PlayerPrefs.GetFloat("Silver", 0);
        GoldCount = 1000;//PlayerPrefs.GetFloat("Gold", 0);
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Silver", SilverCount);
        PlayerPrefs.SetFloat("Gold", GoldCount);
    }
}
