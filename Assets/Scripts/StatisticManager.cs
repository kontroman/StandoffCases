using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatisticManager : MonoBehaviour
{
    public static StatisticManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    private void Update()
    {
        UpdateTimeStatistic();
    }

    public void UpdateTimeStatistic()
    {
        PlayerPrefs.SetFloat("TotalPlayTime", PlayerPrefs.GetFloat("TotalPlayTime", 0f) + Time.deltaTime / 60f);
    }

    public float GetTimeStatistic()
    {
        return PlayerPrefs.GetFloat("TotalPlayTime", 0f);
    }

    public void UpdateRarityStatistic(RarityType rarityOfItem)
    {
        switch (rarityOfItem)
        {
            case RarityType.Arcane:
                PlayerPrefs.SetInt("ArcaneItemStat", (PlayerPrefs.GetInt("ArcaneItemStat", 0) +1 )) ;
                break;
            case RarityType.Legendary:
                PlayerPrefs.SetInt("LegendaryItemStat", (PlayerPrefs.GetInt("LegendaryItemStat", 0) + 1));
                break;
            case RarityType.Epic:
                PlayerPrefs.SetInt("EpicItemStat", (PlayerPrefs.GetInt("EpicItemStat", 0) +1 )) ;
                break;
            case RarityType.Rare:
                PlayerPrefs.SetInt("RareItemStat", (PlayerPrefs.GetInt("RareItemStat", 0) + 1));
                break;
            case RarityType.Uncommon:
                PlayerPrefs.SetInt("UncommonItemStat", (PlayerPrefs.GetInt("UncommonItemStat", 0) +1 )) ;
                break;
            default:
                Debug.Log("Undefined rarity!");
                break;
        }
    }

    public int GetRarityStatistic(RarityType rarityOfItem)
    {
        switch (rarityOfItem)
        {
            case RarityType.Arcane:
                return PlayerPrefs.GetInt("ArcaneItemStat", 0);
            case RarityType.Legendary:
                return PlayerPrefs.GetInt("LegendaryItemStat", 0);
            case RarityType.Epic:
                return PlayerPrefs.GetInt("EpicItemStat", 0);
            case RarityType.Rare:
                return PlayerPrefs.GetInt("RareItemStat", 0);
            case RarityType.Uncommon:
                return PlayerPrefs.GetInt("UncommonItemStat", 0);
            default:
                return -1;
        }
    }

    public void UpdateTypeOfWeaponStatistic(WeaponType weaponType)
    {
        switch(weaponType)
        {
            case WeaponType.Gloves:
                PlayerPrefs.SetInt("GlovesItemStat", (PlayerPrefs.GetInt("GlovesItemStat", 0) + 1));
                break;
            case WeaponType.Sticker:
                PlayerPrefs.SetInt("StickerItemStat", (PlayerPrefs.GetInt("StickerItemStat", 0) + 1));
                break;
            case WeaponType.Charm:
                PlayerPrefs.SetInt("CharmItemStat", (PlayerPrefs.GetInt("CharmItemStat", 0) + 1));
                break;
            case WeaponType.Graffiti:
                PlayerPrefs.SetInt("GraffitiItemStat", (PlayerPrefs.GetInt("GraffitiItemStat", 0) + 1));
                break;
            case WeaponType.Butterfly:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.DualDaggers:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Fang:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Flip:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.JKommando:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Karambit:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Kukri:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Kunai:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.M9:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Scorpion:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Stiletto:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Tanto:
                PlayerPrefs.SetInt("KnifeItemStat", (PlayerPrefs.GetInt("KnifeItemStat", 0) + 1));
                break;
            case WeaponType.Charmpack:
                break;
            case WeaponType.Graffitipack:
                break;
            case WeaponType.Case:
                break;
            case WeaponType.Box:
                break;
            case WeaponType.Stickerpack:
                break;
            default:
                PlayerPrefs.SetInt("GunItemStat", (PlayerPrefs.GetInt("GunItemStat", 0) + 1));
                break;
        }
    }

    public int GetTypeOfWeaponStatistic(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gloves:
                return PlayerPrefs.GetInt("GlovesItemStat", 0);
            case WeaponType.Sticker:
                return PlayerPrefs.GetInt("StickerItemStat", 0);
            case WeaponType.Charm:
                return PlayerPrefs.GetInt("CharmItemStat", 0);
            case WeaponType.Graffiti:
                return PlayerPrefs.GetInt("GraffitiItemStat", 0);
            case WeaponType.Knife:
                return PlayerPrefs.GetInt("KnifeItemStat", 0);
            default:
                return PlayerPrefs.GetInt("GunItemStat", 0);
        }
    }
    public void UpdateOpenCaseStatistic(WeaponType caseType)
    {
        if(caseType == WeaponType.Case)
            PlayerPrefs.SetInt("OpenCaseStat", (PlayerPrefs.GetInt("OpenCaseStat", 0) + 1));
        if(caseType == WeaponType.Box)
            PlayerPrefs.SetInt("OpenBoxStat", (PlayerPrefs.GetInt("OpenBoxStat", 0) + 1));
    }

    public int GetOpenCaseStatistic(WeaponType caseType)
    {
        if (caseType == WeaponType.Case)
            return PlayerPrefs.GetInt("OpenCaseStat", 0);
        if (caseType == WeaponType.Box)
            return PlayerPrefs.GetInt("OpenBoxStat", 0);
        return -1;
    }
}
