using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTxtMove : MonoBehaviour
{
    private Rigidbody2D rb2d = null;
    private RectTransform rectTf = null;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rectTf = GetComponent<RectTransform>();
        rb2d.velocity = Vector2.down * 500f;
    }
    void Update()
    {
        if(rectTf.position.y <= 790)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
