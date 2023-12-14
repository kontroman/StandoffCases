using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyWindow : MonoBehaviour
{
    public Image caseImage;
    public TextMeshProUGUI caseName;

    public int casePrice;

    public TextMeshProUGUI Price;
    public TextMeshProUGUI Counter;

    public Slider slider;
    public GameObject Notific;

    public CaseType _case;

    public void UpdatePrice()
    {
        Price.text = "" + casePrice * slider.value + " " + (_case.moneyType == MoneyType.Silver ? "C" : "G");
        Counter.text = "" + slider.value;
    }

    public void TryBuy()
    {
        for(int i = 0; i < slider.value; i++)
        {
            Inventory.Instance.AddNewItem(_case.Case.caseItemInfo);
        }

        var obj = Instantiate(Notific, GameObject.Find("Canvas").transform);
        obj.GetComponent<notification>().Init(_case.Case.caseItemInfo);

        Destroy(transform.parent.gameObject);
    }

    public void Init(CaseType _cases)
    {
        _case = _cases;

        caseImage.sprite = _case.Case.caseItemInfo.Sprite;
        caseName.text = _case.Case.caseItemInfo.Name;

        Price.text = "" + _case.Price + " " + (_case.moneyType == MoneyType.Silver ? "C" : "G"); ;
        casePrice = _case.Price;
    }

}
