using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSizer : MonoBehaviour
{
    public GridLayoutGroup gridLayout;

    public Vector2 resolution1 = new Vector2(1920, 1080);
    public Vector2 cellSize1 = new Vector2(200, 150);
    public Vector2 spacing1 = new Vector2(-24.8f, -48.1f);

    public Vector2 resolution2 = new Vector2(1280, 720);
    public Vector2 cellSize2 = new Vector2(200, 100);
    public Vector2 spacing2 = new Vector2(-26.3f, 10);

    public Vector2 resolution3 = new Vector2(1612, 720);
    public Vector2 cellSize3 = new Vector2(183.1f, 118.5f);
    public Vector2 spacing3 = new Vector2(18.3f, 0);

    void OnEnable()
    {
        // Получаем текущее разрешение экрана
        Vector2 screenResolution = new Vector2(Screen.width, Screen.height);

        // Проверяем текущее разрешение и устанавливаем соответствующие значения параметров GridLayoutGroup
        if (screenResolution == resolution1)
        {
            gridLayout.cellSize = cellSize1;
            gridLayout.spacing = spacing1;
        }
        else if (screenResolution == resolution2)
        {
            gridLayout.cellSize = cellSize2;
            gridLayout.spacing = spacing2;
        }
        else if (screenResolution == resolution3)
        {
            gridLayout.cellSize = cellSize3;
            gridLayout.spacing = spacing3;
        }
        else
        {
            // Если разрешение не соответствует ни одному из указанных, можно установить значения по умолчанию
            gridLayout.cellSize = new Vector2(200, 150);
            gridLayout.spacing = new Vector2(-24.8f, -48.1f);
        }
    }
}
