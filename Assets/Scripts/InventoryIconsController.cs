using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryIconsController : MonoBehaviour
{
    public ItemIcon[] ItemIcons;

    private int _index = 0;

    //тут короче надо разносить индексы для итемов и иконок
    public void UpdateIcons()
    {
        foreach (ItemIcon icon in ItemIcons)
            icon.gameObject.SetActive(false);

        for (int i = _index; i <= _index + ItemIcons.Length; i++)
        {
            ItemIcons[i].gameObject.SetActive(true);
            ItemIcons[i].UpdateInfo(Inventory.Instance.Items[i]);
        }
    }

    public void NextPageIcons()
    {
        _index += ItemIcons.Length;
        UpdateIcons();
    }

    public void PrevPageIcons()
    {
        _index -= ItemIcons.Length;
        if (_index < 0)
            _index = 0;
        UpdateIcons();
    }
}
