using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    public GameObject CasesWindow;
    public GameObject BoxesWindow;

    public void OpenBoxes()
    {
        CasesWindow.SetActive(false);
        BoxesWindow.SetActive(true);
    }
    public void OpenCases()
    {
        CasesWindow.SetActive(true);
        BoxesWindow.SetActive(false);
    }
}
