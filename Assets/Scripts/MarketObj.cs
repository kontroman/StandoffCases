using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketObj : MonoBehaviour
{
    public Image gunImage;
    public Image Rarity;
    public TextMeshProUGUI Name;
    public string GunName;
    public TextMeshProUGUI Price;
    public GameObject BuyMenul;
    public ItemInfo itemInfo;

    public void Init(ItemInfo info)
    {
        itemInfo = info;
        GetComponent<Button>().onClick.AddListener(BuyMenu);

        if (info.WeaponType == WeaponType.Case ||
            info.WeaponType == WeaponType.Box ||
            info.WeaponType == WeaponType.Charmpack ||
            info.WeaponType == WeaponType.Stickerpack ||
            info.WeaponType == WeaponType.Graffitipack)
        {
            Destroy(gameObject);
            return;
        }
        gunImage.sprite = info.Sprite;
        Name.text = info.Name;
        GunName = info.Name;
        Price.text = "G " + info.Price;

        Color color = Color.white;

        switch (info.RarityType)
        {
            case RarityType.Common:
                color = Color.grey;
                break;
            case RarityType.Uncommon:
                color = Color.cyan;
                break;
            case RarityType.Rare:
                color = Color.blue;
                break;
            case RarityType.Epic:
                color = new Color(0.3f, 0, 1f);
                break;
            case RarityType.Legendary:
                color = new Color(1f, 0, 0.8874888f);
                break;
            case RarityType.Arcane:
                color = Color.red;
                break;
            case RarityType.Gold:
                color = Color.yellow;
                break;
        }

        Rarity.color = color;
    }

    private void BuyMenu()
    {
        var obj = Instantiate(BuyMenul, GameObject.Find("Canvas").transform);
        obj.GetComponentInChildren<BuyItemFromMarket>().Init(itemInfo);
    }
}