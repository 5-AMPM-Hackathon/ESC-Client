using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public float temp = 0f;
    public float multi = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameObject.activeSelf){ return; }
        Color color = new Color();
        color.r = 1f;
        color.g = 1f-temp; // temp 값에 따라서 0부터 1까지 변화
        color.b = 1f-temp;
        color.a = 1f;
        if (temp >= 0.6f)
        {
            multi = -1f;
        }
        else if (temp < 0f)
        {
            multi = 1f;
        }
        temp += multi*0.01f;
        Image image = GetComponent<Image>();
        image.color = color;

    }
}
