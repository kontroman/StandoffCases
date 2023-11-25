using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private ItemInfo _itemInfo;

    public TextMeshProUGUI Name;
    public Image NamePanel;
    public Image Image;

    void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        Name.text = _itemInfo.WeaponType.ToString() + " " + _itemInfo.Name;
        Image.sprite = _itemInfo.Sprite;
        ChoosePanelColor();
    }

    private void ChoosePanelColor()
    {
        switch(_itemInfo.RarityType)
        {
            case RarityType.Common:
                NamePanel.color = RarityColors.Instance.CommonColor;
                return;
            case RarityType.Uncommon:
                NamePanel.color = RarityColors.Instance.UncommonColor;
                return;
            case RarityType.Rare:
                NamePanel.color = RarityColors.Instance.RareColor;
                return;
            case RarityType.Epic:
                NamePanel.color = RarityColors.Instance.EpicColor;
                return;
            case RarityType.Legendary:
                NamePanel.color = RarityColors.Instance.LegendaryColor;
                return;
            case RarityType.Arcane:
                NamePanel.color = RarityColors.Instance.ArcaneColor;
                return;
            case RarityType.Gold:
                NamePanel.color = RarityColors.Instance.ArcaneColor;
                return;
        }
    }
}
