using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyVisualizer : MonoBehaviour
{
    public TextMeshProUGUI text;

    public bool isSilver;

    private void OnEnable()
    {
        UpdateText();
    }

    private void Start()
    {
        PlayerStats.Instance.OnGoldChanged += UpdateText;
        PlayerStats.Instance.OnSilverChanged += UpdateText;

        UpdateText();
    }

    private void UpdateText(float value = 0)
    {
        if (isSilver)
        {
            text.text = "C " + PlayerStats.Instance.SilverCount;
        }
        else
        {
            text.text = "G " + PlayerStats.Instance.GoldCount;
        }
    }
}
