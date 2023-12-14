using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;

public class ItemIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemInfo _itemInfo;

    public TextMeshProUGUI Name;
    public Image NamePanel;
    public Image Image;
    public GameObject ItemWindow;

    public void UpdateInfo(ItemInfo itemInfo)
    {
        _itemInfo = itemInfo;
        Name.text = _itemInfo.WeaponType.ToString() + " " + _itemInfo.Name;
        Image.sprite = _itemInfo.Sprite;
        ChoosePanelColor();
    }

    private void ChoosePanelColor()
    {
        switch (_itemInfo.RarityType)
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
                NamePanel.color = RarityColors.Instance.GoldColor;
                return;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_itemInfo.WeaponType == WeaponType.Case ||
            _itemInfo.WeaponType == WeaponType.Charmpack ||
            _itemInfo.WeaponType == WeaponType.Stickerpack ||
            _itemInfo.WeaponType == WeaponType.Graffitipack ||
            _itemInfo.WeaponType == WeaponType.Box)
        {
            List<Case> list = new List<Case>();

            list = FindObjectsOfType<Case>().ToList();

            Inventory.Instance.CaseOpening.gameObject.SetActive(true);
            Inventory.Instance.CaseOpening.Init(list.Find(x => x.caseItemInfo == _itemInfo));
            GameObject.Find("InventoryPage").SetActive(false);
        }
        else
        {
            WindowManager.Instance.ShowItemWindow(_itemInfo);
        }
    }
}
