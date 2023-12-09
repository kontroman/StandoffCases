using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class StatisticPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _knifeStatistic;
    [SerializeField] private TextMeshProUGUI _glovesStatistic;
    [SerializeField] private TextMeshProUGUI _charmStatistic;
    [SerializeField] private TextMeshProUGUI _stickerStatistic;
    [SerializeField] private TextMeshProUGUI _graffitiStatistic;
    [SerializeField] private TextMeshProUGUI _gunStatistic;

    [SerializeField] private TextMeshProUGUI _arcaneStatisticAmount;
    [SerializeField] private TextMeshProUGUI _legendaryStatisticAmount;
    [SerializeField] private TextMeshProUGUI _epicStatisticAmount;
    [SerializeField] private TextMeshProUGUI _rareStatisticAmount;
    [SerializeField] private TextMeshProUGUI _uncommonStatisticAmount;


    [SerializeField] private TextMeshProUGUI _arcaneStatisticPrecent;
    [SerializeField] private TextMeshProUGUI _legendaryStatisticPrecent;
    [SerializeField] private TextMeshProUGUI _epicStatisticPrecent;
    [SerializeField] private TextMeshProUGUI _rareStatisticPrecent;
    [SerializeField] private TextMeshProUGUI _uncommonStatisticPrecent;

    [SerializeField] private TextMeshProUGUI _timeStatistic;

    [SerializeField] private TextMeshProUGUI _openCaseStatistic;
    [SerializeField] private TextMeshProUGUI _openBoxStatistic;
    [SerializeField] private TextMeshProUGUI _caseToBoxStatistic;
    [SerializeField] private Image _circle;

    private void Start()
    {
        ShowInfo();

    }

    private void OnEnable()
    {
        //ShowInfo();
    }

    public void ShowInfo()
    {
        _knifeStatistic.text = StatisticManager.Instance.GetTypeOfWeaponStatistic(WeaponType.Knife).ToString();
        _glovesStatistic.text = StatisticManager.Instance.GetTypeOfWeaponStatistic(WeaponType.Gloves).ToString();
        _charmStatistic.text = StatisticManager.Instance.GetTypeOfWeaponStatistic(WeaponType.Charm).ToString();
        _stickerStatistic.text = StatisticManager.Instance.GetTypeOfWeaponStatistic(WeaponType.Sticker).ToString();
        _graffitiStatistic.text = StatisticManager.Instance.GetTypeOfWeaponStatistic(WeaponType.Graffiti).ToString();
        _gunStatistic.text = StatisticManager.Instance.GetTypeOfWeaponStatistic(WeaponType.AKR).ToString();

        int arcaneStatisticAmount = StatisticManager.Instance.GetRarityStatistic(RarityType.Arcane);
        int legendaryStatisticAmount = StatisticManager.Instance.GetRarityStatistic(RarityType.Legendary);
        int epicStatisticAmount = StatisticManager.Instance.GetRarityStatistic(RarityType.Epic);
        int rareStatisticAmount = StatisticManager.Instance.GetRarityStatistic(RarityType.Rare);
        int uncommonStatisticAmount = StatisticManager.Instance.GetRarityStatistic(RarityType.Uncommon);

        float totalItemAmount = arcaneStatisticAmount + legendaryStatisticAmount + epicStatisticAmount + rareStatisticAmount + uncommonStatisticAmount;

        _arcaneStatisticAmount.text = arcaneStatisticAmount.ToString();
        _legendaryStatisticAmount.text = legendaryStatisticAmount.ToString();
        _epicStatisticAmount.text = epicStatisticAmount.ToString();
        _rareStatisticAmount.text = rareStatisticAmount.ToString();
        _uncommonStatisticAmount.text = uncommonStatisticAmount.ToString();

        float arcaneStatrsticPrecent;
        float legendaryStatrsticPrecent;
        float epicStatrsticPrecent;
        float rareStatrsticPrecent;
        float uncommonStatrsticPrecent;
        
        if (totalItemAmount != 0)
        {
            arcaneStatrsticPrecent = (float)(arcaneStatisticAmount / totalItemAmount * 100);
            legendaryStatrsticPrecent = (float)(legendaryStatisticAmount / totalItemAmount * 100);
            epicStatrsticPrecent = (float)(epicStatisticAmount / totalItemAmount * 100);
            rareStatrsticPrecent = (float)(rareStatisticAmount / totalItemAmount * 100);
            uncommonStatrsticPrecent = (float)(uncommonStatisticAmount / totalItemAmount * 100);

            _arcaneStatisticPrecent.text = arcaneStatrsticPrecent.ToString("F2") + "%";
            _legendaryStatisticPrecent.text = legendaryStatrsticPrecent.ToString("F2") + "%";
            _epicStatisticPrecent.text = epicStatrsticPrecent.ToString("F2") + "%";
            _rareStatisticPrecent.text = rareStatrsticPrecent.ToString("F2") + "%";
            _uncommonStatisticPrecent.text = uncommonStatrsticPrecent.ToString("F2") + "%";
        }
        else
        {
            _arcaneStatisticPrecent.text = "0%";
            _legendaryStatisticPrecent.text = "0%";
            _epicStatisticPrecent.text =  "0%";
            _rareStatisticPrecent.text = "0%";
            _uncommonStatisticPrecent.text = "0%";
        }

        float openCaseAmount = StatisticManager.Instance.GetOpenCaseStatistic(WeaponType.Case);
        float openBoxAmount = StatisticManager.Instance.GetOpenCaseStatistic(WeaponType.Box);
        _openCaseStatistic.text = openCaseAmount.ToString();
        _openBoxStatistic.text = openBoxAmount.ToString();
        if (openBoxAmount == 0)
            openBoxAmount = 1;
        float caseToBox = openCaseAmount / openBoxAmount;
        _circle.GetComponent<Image>().fillAmount = caseToBox;
        _caseToBoxStatistic.text = (caseToBox).ToString("F2");

        _timeStatistic.text = TimeStatisticLine();
    }

    private string TimeStatisticLine()
    {
        string result = "Общее время в игре: ";
        var time = StatisticManager.Instance.GetTimeStatistic();
        int hours = (int)(time / 60);
        result += hours.ToString() + " часов ";
        int minutes = (int)(time - (hours * 60));
        result += minutes.ToString() + " минут(ы)";
        return result;
    }
}
