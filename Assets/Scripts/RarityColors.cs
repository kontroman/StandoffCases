using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RarityColors : MonoBehaviour
{
    public static RarityColors Instance { get; set; }

    public Color32 CommonColor;
    public Color32 UncommonColor;
    public Color32 RareColor;        
    public Color32 EpicColor;           
    public Color32 LegendaryColor;      
    public Color32 ArcaneColor;         
    public Color32 GoldColor;

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }
}
