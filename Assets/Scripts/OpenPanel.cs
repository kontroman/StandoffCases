using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public Button Buy;
    public Button Look;
    public Case _case;
    public CaseType caseType;
    public GameObject _go;
    public GameObject _buyMenu;

    public void Init(Case Case, GameObject casePreview, CaseType _caseType)
    {
        _go = casePreview;
        _case = Case;
        caseType = _caseType;
        Look.onClick.AddListener(LookCase);
        Buy.onClick.AddListener(BuyCase);
    }

    public void LookCase()
    {
        _go.SetActive(true);
        _go.GetComponent<CasePreview>().InitPreview(_case, caseType);

        GameObject.Find("InventoryPage").SetActive(false);
        Destroy(gameObject);
    }

    public void BuyCase()
    {
        var obj = Instantiate(_buyMenu, GameObject.Find("Canvas").transform);
        obj.GetComponentInChildren<BuyWindow>().Init(caseType);
        Destroy(gameObject);
    }
}
