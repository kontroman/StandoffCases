using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstPanelName : MonoBehaviour
{
    public TextMeshProUGUI _input;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
            Destroy(gameObject);
    }

    public void Apply()
    {
        if (string.IsNullOrEmpty(_input.text)) return;

        PlayerPrefs.SetString("PlayerName", _input.text);
        PlayerPrefs.SetInt("ID", Random.Range(135829, 782945));
        Destroy(gameObject);
    }
}
