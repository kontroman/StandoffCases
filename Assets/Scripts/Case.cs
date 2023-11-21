using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public List<int> ItemsId;

    void Start()
    {
        //InvokeRepeating("Test", 1f, 1f);
    }

    public void Test()
    {
        var temp = GetItem();
        Debug.Log(temp.Name + " " + temp.RarityType);
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

    private RarityType GetRarityOfItem()
    {
        var res = Random.value;
        Debug.Log(res);
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

}
