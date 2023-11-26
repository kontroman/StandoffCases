using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; set; }
    
    public List<ItemInfo> Items = new List<ItemInfo>();

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    private void Start()
    {
        UploadInventory();
    }

    public void AddNewItem(ItemInfo newItem)
    {
        Items.Add(newItem);
        SaveInventory();
    }

    public void DeleteItem(ItemInfo item)
    {
        Items.RemoveAt(Items.IndexOf(item));
        SaveInventory();
    }

    public void UploadInventory()
    {
        string temp = PlayerPrefs.GetString("Data", string.Empty);
        string[] ids = temp.Split('_');

        foreach (string id_string in ids)
        {
            if(id_string != "")
                AddNewItem(ItemDatabase.Instance.GetItemById(Convert.ToInt32(id_string)));
        }
    }

    public void SaveInventory()
    {
        string data = "";
        foreach (ItemInfo item in Items)
        {
            data += ItemDatabase.Instance.GetId(item).ToString();
            data += "_";
        }
        PlayerPrefs.SetString("Data", data);
        Debug.Log(data);
    }
}
