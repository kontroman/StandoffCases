using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public Image One;
    public Image Two;
    public Image Three;

    public GameObject OneWindow;
    public GameObject TwoWindow;
    public GameObject ThreeWidnow;

    public void OnDisable()
    {
        OneWindow.SetActive(false);
        TwoWindow.SetActive(false);
        ThreeWidnow.SetActive(false);
    }

    public void OnEnable()
    {
        OpenOne();
    }

    public void OpenOne()
    {
        OneWindow.SetActive(true);
        TwoWindow.SetActive(false);
        ThreeWidnow.SetActive(false);

        One.color = new Color(One.color.r, One.color.g, One.color.b, 100);
        Two.color = new Color(One.color.r, One.color.g, One.color.b, 0);
        Three.color = new Color(One.color.r, One.color.g, One.color.b, 0);
    }
    public void OpenTwo()
    {
        OneWindow.SetActive(false);
        TwoWindow.SetActive(true);
        ThreeWidnow.SetActive(false);

        One.color = new Color(One.color.r, One.color.g, One.color.b, 0);
        Two.color = new Color(One.color.r, One.color.g, One.color.b, 100);
        Three.color = new Color(One.color.r, One.color.g, One.color.b, 0);
    }
    public void OpenThree()
    {
        OneWindow.SetActive(false);
        TwoWindow.SetActive(false);
        ThreeWidnow.SetActive(true);

        One.color = new Color(One.color.r, One.color.g, One.color.b, 0);
        Two.color = new Color(One.color.r, One.color.g, One.color.b, 0);
        Three.color = new Color(One.color.r, One.color.g, One.color.b, 100);
    }
}
