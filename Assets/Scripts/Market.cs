using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public List<MarketObj> items = new List<MarketObj>();

    public MarketObj prefab;
    public Transform parentView;

    private bool rarityUp;
    private bool nameUp;

    public TMP_InputField inputField;

    public void Start()
    {
        foreach (var item in ItemDatabase.Instance._data)
        {
            if (item.WeaponType == WeaponType.Case ||
                item.WeaponType == WeaponType.Box ||
                item.WeaponType == WeaponType.Graffitipack ||
                item.WeaponType == WeaponType.Stickerpack ||
                item.WeaponType == WeaponType.Charmpack)
                continue;

            var obj = Instantiate<MarketObj>(prefab, parentView);
            obj.Init(item);
            items.Add(obj);
        }

        parentView.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 156 + items.Count / 5 * 156);

        SortByRarity();
    }

    public void SortByRarity()
    {
        if (rarityUp)
        {
            var sortedList = items
               .OrderBy(x => (int)(x.itemInfo.RarityType))
               .ToList();

            foreach (var item in sortedList)
            {
                item.transform.SetAsLastSibling();
            }

            rarityUp = !rarityUp;
            return;
        }
        else
        {
            var sortedList = items
               .OrderBy(x => (int)(x.itemInfo.RarityType))
               .ToList();

            foreach (var item in sortedList)
            {
                item.transform.SetAsFirstSibling();
            }

            rarityUp = !rarityUp;
            return;
        }
    }

    public void SortByName()
    {
        if (nameUp)
        {
            var sortedList = items
               .OrderBy(x => x.itemInfo.Price)
               .ToList();

            foreach (var item in sortedList)
            {
                item.transform.SetAsLastSibling();
            }

            nameUp = !nameUp;
            return;
        }
        else
        {
            var sortedList = items
               .OrderBy(x => x.itemInfo.Price)
               .ToList();

            foreach (var item in sortedList)
            {
                item.transform.SetAsFirstSibling();
            }

            nameUp = !nameUp;
            return;
        }
    }

    public void SearchByName()
    {
        string searchTerm = inputField.text.ToLowerInvariant().Trim();

        List<MarketObj> filteredObj = new List<MarketObj>();

        foreach(MarketObj item in items)
        {
            if (item.GunName.ToLowerInvariant().Trim().Contains(searchTerm))
                filteredObj.Add(item);
        }

        foreach (var item in filteredObj)
        {
            item.transform.SetAsFirstSibling();
        }
    }
}
