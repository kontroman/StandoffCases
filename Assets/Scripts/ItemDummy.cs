using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDummy : MonoBehaviour
{
    public Image SkinImage;
    public TextMeshProUGUI SkinName;
    public Image RarityImage;
    public ItemInfo info;

    private void Awake()
    {
        InitDummy(info);
    }

    public void InitDummy(ItemInfo _info)
    {
        SkinImage.sprite = _info.Sprite;
        SkinName.text = "" + _info.Name;

        Color color = Color.white;

        switch (_info.RarityType)
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

        RarityImage.color = color;
    }
}
