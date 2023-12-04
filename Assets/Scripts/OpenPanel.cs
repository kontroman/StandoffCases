using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public Button Buy;
    public Button Look;
    public Case _case;
    public GameObject _go;

    public void Init(Case Case, GameObject casePreview)
    {
        _go = casePreview;
        _case = Case;
        Look.onClick.AddListener(LookCase);
    }

    public void LookCase()
    {
        _go.SetActive(true);
        _go.GetComponent<CasePreview>().InitPreview(_case);

        GameObject.Find("InventoryPage").SetActive(false);
        Destroy(gameObject);
    }

}
