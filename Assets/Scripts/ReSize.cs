using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReSize : MonoBehaviour {

    public RectTransform image;

    private float width, height;
    private bool up = true;

    private void Awake()
    {
        //width = image.sizeDelta;
        width = image.sizeDelta.x;
        height = image.sizeDelta.y;
        StartCoroutine(ReSiz());
    }

    IEnumerator ReSiz()
    {
        if (up)
        {
            width++;
            height++;
            image.sizeDelta = new Vector2(width, height); ;
            if (width >= 65 || height >= 100)
                up = false;
        }
        else
        {
            width--;
            height--;
            image.sizeDelta = new Vector2(width, height); ;
            if (width <= 50 || height <= 85)
                up = true;
        }
        yield return new WaitForSeconds(.05f);
        StartCoroutine(ReSiz());
    }
}
