using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CaseType : MonoBehaviour
{
    public string Name;
    public int Price;
    public string NameCaseType;


    public MoneyType moneyType;

    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextPrice;

    private void Awake()
    {
        TextName = transform.Find("Top/Name").GetComponent<TextMeshProUGUI>();
        TextPrice = transform.Find("CaseImage/Price").GetComponent<TextMeshProUGUI>();

        TextName.text = $"\"{ Name}\" " + NameCaseType;
        TextPrice.text = (moneyType == MoneyType.Silver ? "C " + Price : "G " + Price);

        GetComponent<Button>().onClick.AddListener(OpenBuyPanel);
    }

    private void OpenBuyPanel()
    {
        List<OpenPanel> panels = GameObject.FindObjectsOfType<OpenPanel>().ToList();

        foreach(OpenPanel _panel in panels)
        {
            Destroy(_panel.gameObject);
        }


        var panel = Instantiate(Resources.Load<GameObject>("OpenPanel"), transform).GetComponent<OpenPanel>();
    }
}
