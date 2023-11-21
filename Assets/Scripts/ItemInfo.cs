using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemInfo : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite Sprite;
    public RarityType RarityType;
}
