using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI id;

    public void OnEnable()
    {
        name.text = PlayerPrefs.GetString("PlayerName");
        id.text = "" + PlayerPrefs.GetInt("ID");
    }
}
