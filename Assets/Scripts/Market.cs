using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public List<ItemInfo> items = new List<ItemInfo>();

    public GameObject prefab;
    public Transform parentView;

    public void Start()
    {
        foreach (var item in ItemDatabase.Instance._data)
        {
            var obj = Instantiate(prefab, parentView);
            obj.GetComponent<MarketObj>().Init(item);
            items.Add(item);
        }

        parentView.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 285 + items.Count / 4 * 285);
    }


}
