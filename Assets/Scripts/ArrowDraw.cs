using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
            arrowImage.gameObject.SetActive(true);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 dist = clickPos - Input.mousePosition;
            float size = dist.magnitude;
            float angle = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
            arrowImage.rectTransform.position = clickPos;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size * 0.5f);
        }else {
            arrowImage.gameObject.SetActive(false);
        }


    }
}
