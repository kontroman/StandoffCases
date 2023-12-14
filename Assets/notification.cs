using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class notification : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;

    public void Init(ItemInfo info)
    {
        Image.sprite = info.Sprite;
        Name.text = info.Name + " получен";
        Price.text = "Стоимость: " + info.Price;
    }
}
