using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemInfo : ScriptableObject
{
    public int Id;
    public string Name;
    public float Price;
    public Sprite Sprite;
    public RarityType RarityType;
    public WeaponType WeaponType;
    public Collections Collection;
}
