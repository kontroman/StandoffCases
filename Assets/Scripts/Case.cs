using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Case : MonoBehaviour
{
    public ItemInfo caseItemInfo;
    public List<int> ItemsId;
    public bool isFullSetRarieties;
    public string Name;
    List<ItemInfo> items = new List<ItemInfo>();
    public bool addToBoxStatistic;
    public bool addToCaseStatistic;

    public void Open()
    {
        var item = GetItem();
        Inventory.Instance.AddNewItem(item);
        Debug.Log(item.Name + " " + item.RarityType);
    }

    public void InitCase()
    {
        foreach (var item in ItemsId)
        {
            items.Add(ItemDatabase.Instance.GetItemById(item));
        }
    }

    public ItemInfo GetItem()
    {
        var pool = GetItemPoolOfDifiniteRarity(GetRarityOfItem());
        return pool[Random.Range(0, pool.Count)];
    }

    private List<ItemInfo> GetItemPoolOfDifiniteRarity(RarityType rarity)
    {
        List<ItemInfo> itemPool = new List<ItemInfo>();
        foreach (int id in ItemsId)
        {
            var item = ItemDatabase.Instance.GetItemById(id);
            if (item.RarityType == rarity)
                itemPool.Add(item);
        }
        return itemPool;
    }

    public ItemInfo GetRandomItem()
    {
        InitCase();

        items.Shuffle();

        var res = Random.value;

        if (isFullSetRarieties)
        {
            if (res < 0.6)
            {
                return items.Find(x => x.RarityType == RarityType.Common);
            }
            else if (res < 0.75)
            {
                return items.Find(x => x.RarityType == RarityType.Uncommon);
            }
            else if (res < 0.85)
            {
                return items.Find(x => x.RarityType == RarityType.Rare);
            }
            else if (res < 0.9)
            {
                return items.Find(x => x.RarityType == RarityType.Epic);
            }
            else if (res < 0.93)
            {
                return items.Find(x => x.RarityType == RarityType.Legendary);
            }
            else if (res < 0.94)
            {
                return items.Find(x => x.RarityType == RarityType.Arcane);
            }
            else
            {
                return items.Find(x => x.RarityType == RarityType.Common);
            }
        }
        else
        {
            if (res < 0.65)
            {
                return items.Find(x => x.RarityType == RarityType.Rare);
            }
            else if (res < 0.85)
            {
                return items.Find(x => x.RarityType == RarityType.Epic);
            }
            else if (res < 0.95)
            {
                return items.Find(x => x.RarityType == RarityType.Legendary);
            }
            else if (res <= 1)
            {
                return items.Find(x => x.RarityType == RarityType.Arcane);
            }
            else
            {
                return items.Find(x => x.RarityType == RarityType.Rare);
            }
        }
    }

    private RarityType GetRarityOfItem()
    {
        var res = Random.value;

        if (isFullSetRarieties)
        {
            if (res < 0.6)
            {
                return RarityType.Common;
            }
            else if (res < 0.75)
            {
                return RarityType.Uncommon;
            }
            else if (res < 0.85)
            {
                return RarityType.Rare;
            }
            else if (res < 0.9)
            {
                return RarityType.Epic;
            }
            else if (res < 0.93)
            {
                return RarityType.Legendary;
            }
            else if (res < 0.94)
            {
                return RarityType.Arcane;
            }
            else
            {
                return RarityType.Common;
            }
        }

        else
        {
            if (res < 0.65)
            {
                return RarityType.Rare;
            }
            else if (res < 0.85)
            {
                return RarityType.Epic;
            }
            else if (res < 0.95)
            {
                return RarityType.Legendary;
            }
            else if (res <= 1)
            {
                return RarityType.Arcane;
            }
            else
            {
                return RarityType.Rare;
            }
        }
    }


}

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}