using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class CasePreview : MonoBehaviour
{
    public TextMeshProUGUI CaseName;
    public GameObject ItemPreviewPrefab;
    public ItemDatabase Database;
    public Transform PreviewParent;
    public Case TestCase;
    public GameObject ButtonsPanel;

    List<ItemDummy> dummies = new List<ItemDummy>();

    private void OnEnable()
    {
        ButtonsPanel.SetActive(false);
    }

    public void InitPreview(Case _case)
    {
        CaseName.text = _case.Name;

        foreach(int i in _case.ItemsId)
        {
            var obj = Instantiate(ItemPreviewPrefab);
            dummies.Add(obj.GetComponent<ItemDummy>());
            obj.GetComponent<ItemDummy>().InitDummy(Database._data[i]);
        }

        int[] map = new[] { 0, 1, 2, 3,4,5,6 };

        var sortedList = dummies
           .OrderBy(x => (int)(x.RarityType))
           .ToList();

        foreach (var item in sortedList)
        {
            item.transform.SetParent(PreviewParent);
        }
    }
}
