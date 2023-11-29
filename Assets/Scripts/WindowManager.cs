using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Instance { get; set; }
    public GameObject ItemWindow;
 
    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }
    
    public void ShowItemWindow(ItemInfo item)
    {
        if (!ItemWindow.activeSelf)
        {
            ItemWindow.SetActive(true);
            ItemWindow.GetComponent<ItemWindow>().Show(item);
        }
    }

    public void CloseItemWindow()
    {
        ItemWindow.SetActive(false);
    }
}
