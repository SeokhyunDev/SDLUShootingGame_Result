using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    [SerializeField] GameObject background1 = null;
    [SerializeField] GameObject background2 = null;
    [SerializeField] Transform minPos = null;
    [SerializeField] Transform maxPos = null;

    private void Update()
    {
        background1.transform.Translate(Vector2.left * speed * Time.deltaTime);
        background2.transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(background1.transform.position.x <= minPos.position.x)
        {
            background1.transform.position = maxPos.position;
        }
        if(background2.transform.position.x <= minPos.position.x)
        {
            background2.transform.position = maxPos.position;
        }
    }
}
