using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaseOpening : MonoBehaviour
{
    public TextMeshProUGUI CaseName;
    public GameObject ItemPreviewPrefab;
    public GameObject ItemPreviewPrefab2;
    public GameObject Notific;
    public ItemDatabase Database;
    public Transform PreviewParent;
    public Transform PreviewParent2;
    public Case TestCase;
    public GameObject ButtonsPanel;
    public Scrollbar scrollbar;
    public GameObject button;

    public GameObject invento1;
    public GameObject invento2;

    public AudioSource roulette;

    List<ItemDummy> dummies = new List<ItemDummy>();

    public ItemInfo ItemToGive;

    private void OnEnable()
    {
        ButtonsPanel.SetActive(false);
    }

    private void OnDisable()
    {
        foreach (var item in dummies)
        {
            Destroy(item.gameObject);
        }
        dummies.Clear();
    }

    public void Init(Case _case)
    {
        CaseName.text = _case.Name;
        TestCase = _case;
        button.gameObject.SetActive(true);

        InitPreview(TestCase);
        CreateItems();
    }

    public void CreateItems()
    {
        for(int i = 0; i < 50; i++)
        {
            ItemInfo item = null;

            while(item == null)
            {
                item = TestCase.GetRandomItem();
            }

            var obj = Instantiate(ItemPreviewPrefab, PreviewParent);
            obj.GetComponent<OpeningItem>().Init(item);

            if(i == 44)
            {
                ItemToGive = item;
            }
        }
    }

    public void InitPreview(Case _case)
    {
        CaseName.text = _case.Name;

        foreach (int i in _case.ItemsId)
        {
            var obj = Instantiate(ItemPreviewPrefab2);
            dummies.Add(obj.GetComponent<ItemDummy>());
            obj.GetComponent<ItemDummy>().InitDummy(Database._data[i]);
        }

        var sortedList = dummies
           .OrderBy(x => (int)(x.RarityType))
           .ToList();

        foreach (var item in sortedList)
        {
            item.transform.SetParent(PreviewParent2);
        }
    }


    //Âûהאול 45ûי ןנוהלוע
    public void OpenCase()
    {
        button.SetActive(false);
        StartCoroutine(Open());
        roulette.Play();
    }

    private IEnumerator Open()
    {
        while(scrollbar.value < 0.7)
        {
            scrollbar.value += 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.8)
        {
            scrollbar.value += 0.0035f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.85)
        {
            scrollbar.value += 0.002f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.9)
        {
            scrollbar.value += 0.0015f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.91)
        {
            scrollbar.value += 0.001f;
            yield return new WaitForSeconds(0.01f);
        } 
        while (scrollbar.value < 0.93)
        {
            scrollbar.value += 0.0008f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.95)
        {
            scrollbar.value += 0.0006f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.965)
        {
            scrollbar.value += 0.0004f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.975)
        {
            scrollbar.value += 0.00025f;
            yield return new WaitForSeconds(0.01f);
        }
        while (scrollbar.value < 0.9827269f)
        {
            scrollbar.value += 0.00008f;
            yield return new WaitForSeconds(0.01f);
        }

        Inventory.Instance.AddNewItem(ItemToGive);
        StatisticManager.Instance.UpdateRarityStatistic(ItemToGive.RarityType);
        StatisticManager.Instance.UpdateTypeOfWeaponStatistic(ItemToGive.WeaponType);
        if (TestCase.addToBoxStatistic)
            StatisticManager.Instance.UpdateOpenCaseStatistic(WeaponType.Box);
        if (TestCase.addToCaseStatistic)
            StatisticManager.Instance.UpdateOpenCaseStatistic(WeaponType.Case);


        var obj = Instantiate(Notific, GameObject.Find("Canvas").transform);
        obj.GetComponent<notification>().Init(ItemToGive);

        yield return new WaitForSeconds(1f);
        HideWindow();
    }

    public void HideWindow()
    {
        dummies.ForEach(x => Destroy(x.gameObject));
        dummies.Clear();
        scrollbar.value = 0;
        ItemToGive = null;

        foreach(Transform t in PreviewParent)
        {
            Destroy(t.gameObject);
        }

        Inventory.Instance.DeleteItemBy(TestCase.caseItemInfo);

        invento1.SetActive(true);
        invento2.SetActive(true);
        ButtonsPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
