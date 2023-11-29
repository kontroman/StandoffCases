using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryIconsController : MonoBehaviour
{
    public ItemIcon[] ItemIcons;

    [SerializeField] private int _page;

    public void UpdateIcons()
    {
        int _index = 0;

        foreach (ItemIcon icon in ItemIcons)
        {
            if(_index + _page * ItemIcons.Length < Inventory.Instance.Items.Count)
            {
                icon.gameObject.SetActive(true);
                icon.UpdateInfo(Inventory.Instance.Items[_index + _page*ItemIcons.Length]);
                _index++;
            }
        }
    }

    public void NextPageIcons()
    {
        if (Inventory.Instance.Items.Count - (_page+1) * ItemIcons.Length > 0)
        {
            _page++;

            foreach (ItemIcon icon in ItemIcons)
                icon.gameObject.SetActive(false);

            UpdateIcons();
        }
    }

    public void PrevPageIcons()
    {
        if (_page > 0)
        {
            _page--;

            foreach (ItemIcon icon in ItemIcons)
                icon.gameObject.SetActive(false);

            UpdateIcons();
        }
    }
}
