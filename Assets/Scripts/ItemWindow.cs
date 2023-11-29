using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemWindow : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Rarity;
    public TextMeshProUGUI Collection;

    [SerializeField] private ItemInfo _itemInfo;

    public void Show(ItemInfo item)
    {
        SetItemInfo(item);
        UpdateInfo();
    }

    public void SetItemInfo(ItemInfo item)
    {
        _itemInfo = item;
    }

    public void UpdateInfo()
    {
        Image.sprite = _itemInfo.Sprite;
        Name.text = "��������: ";
        Rarity.text = "��������: ";
        Collection.text = "���������: ";
        Price.text = "����: ";

        Image.sprite = _itemInfo.Sprite;
        Name.text += _itemInfo.WeaponType.ToString() + " " + _itemInfo.Name;
        Rarity.text += _itemInfo.RarityType.ToString();
        Collection.text += _itemInfo.Collection.ToString();
        Price.text += _itemInfo.Price.ToString() + " G";
        ChooseTextColor();
    }

    private void ChooseTextColor()
    {
        switch (_itemInfo.RarityType)
        {
            case RarityType.Common:
                Rarity.color = RarityColors.Instance.CommonColor;
                return;
            case RarityType.Uncommon:
                Rarity.color = RarityColors.Instance.UncommonColor;
                return;
            case RarityType.Rare:
                Rarity.color = RarityColors.Instance.RareColor;
                return;
            case RarityType.Epic:
                Rarity.color = RarityColors.Instance.EpicColor;
                return;
            case RarityType.Legendary:
                Rarity.color = RarityColors.Instance.LegendaryColor;
                return;
            case RarityType.Arcane:
                Rarity.color = RarityColors.Instance.ArcaneColor;
                return;
            case RarityType.Gold:
                Rarity.color = RarityColors.Instance.ArcaneColor;
                return;
        }
    }
}