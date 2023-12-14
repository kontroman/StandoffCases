using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemFromMarket : MonoBehaviour
{
    public Image caseImage;
    public Image Rarity;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI PriceText;

    public float Price;

    public GameObject Notific;

    private ItemInfo itemInfo;

    public void Init(ItemInfo item)
    {
        itemInfo = item;

        caseImage.sprite = item.Sprite;
        Name.text = item.Name;
        PriceText.text = "" + item.Price + " G";
        Price = item.Price;

        Color color = Color.white;

        switch (item.RarityType)
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
    public void TryBuy()
    {
        if (PlayerStats.Instance.GoldCount < Price) return;

        Inventory.Instance.AddNewItem(itemInfo);

        var obj = Instantiate(Notific, GameObject.Find("Canvas").transform);
        obj.GetComponent<notification>().Init(itemInfo);

        PlayerStats.Instance.GoldCount -= Price;
        PlayerStats.Instance.SaveData();

        Destroy(transform.parent.gameObject);
    }
}
