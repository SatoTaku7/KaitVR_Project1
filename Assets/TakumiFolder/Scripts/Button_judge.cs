using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Button_judge : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            //image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
    }
}
