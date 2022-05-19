using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    SpriteRenderer sp = null;
    
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = true;
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn() 
    {
        Color temp = sp.color;
        while(sp.color.a >= 0)
        {
            temp.a -= 0.01f;
            yield return new WaitForSeconds(0.025f);
            sp.color = temp;
        }
    }
}
