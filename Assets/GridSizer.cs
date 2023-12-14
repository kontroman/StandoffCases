using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSizer : MonoBehaviour
{
    public GridLayoutGroup GridLayoutGroup;

    private void OnEnable()
    {
        //GridLayoutGroup.cellSize = new Vector2(Screen.width / 6.4f, Screen.height / 9);
        GridLayoutGroup.spacing = new Vector2(-(GridLayoutGroup.cellSize.x / 2.3f), -(GridLayoutGroup.cellSize.y / 4f));
    }
}
