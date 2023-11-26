using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject[] Pages;

    private int _actualPageId = -1;

    public void SwitchPage(int newPageId)
    {
        if (_actualPageId != newPageId)
        {
            foreach (GameObject page in Pages)
                page.SetActive(false);
            Pages[newPageId].SetActive(true);
        }
    }
}
