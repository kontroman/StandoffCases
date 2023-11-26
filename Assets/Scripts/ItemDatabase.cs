using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }

    [SerializeField] private List<ItemInfo> _data = new List<ItemInfo>();

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    public ItemInfo GetItemById(int id)
    {
        return _data[id];
    }

    public ItemInfo GetItemByName(string name)
    {
        foreach (ItemInfo item in _data)
        {
            if (item.Name == name)
                return item;
        }

        return null;
    }

    public int GetId(ItemInfo item)
    {
        return _data.IndexOf(item);
    }
}
