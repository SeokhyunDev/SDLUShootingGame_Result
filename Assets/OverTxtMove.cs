using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverTxtMove : MonoBehaviour
{
    private Rigidbody2D rb2d = null;
    private RectTransform rectTf = null;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rectTf = GetComponent<RectTransform>();
        rb2d.velocity = Vector2.left * 1000f;
    }
    void Update()
    {
        if(rectTf.position.x <= 1160)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
