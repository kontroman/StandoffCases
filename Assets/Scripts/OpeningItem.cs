using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpeningItem : MonoBehaviour
{
    public Image gunImage;
    public Image BottomPanel;
    public TextMeshProUGUI gunName;

    public void Init(ItemInfo itemInfo)
    {
        gunImage.sprite = itemInfo.Sprite;
        gunName.text = itemInfo.Name;

        Color color = Color.white;

        switch (itemInfo.RarityType)
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

        BottomPanel.color = color;
    }
}
